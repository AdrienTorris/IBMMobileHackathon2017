namespace IBM.Books.Catalog.API.Services
{
    using IBM.Books.Catalog.API.BusinessModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using IBM.Books.Catalog.API.Infrastructure.Helpers;

    /// <summary>
    /// 
    /// </summary>
    /// <see cref="http://isbndb.com/api/v2/docs/books"/>
    public sealed class ISBNDBAPIService : IBookExternalService
    {
        private const string _API_KEY = "V1O4EG2G";

        private const string _API_BASE_URL = "http://isbndb.com/api/v2/json/" + _API_KEY;

        public ISBNDBAPIService()
        { }

        public async Task<BookReferenceModel> GetBookReferenceDetailsAsync(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentNullException(nameof(isbn));

            string response;
            DataContractJsonSerializer serializer;
            BookISBNSearchResult searchResult;
            BookReferenceModel ret;

            try
            {
                using (var client = new HttpClient())
                {


                    //using (var streamTask = client.GetStreamAsync(_API_BASE_URL + "/book/" + isbn))
                    //{
                    //    DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
                    //    IList<Type> typesList = new List<Type>();
                    //    typesList.Add(typeof(BookISBNSearchResult));
                    //    typesList.Add(typeof(ISBNDBISBNSearchResult));
                    //    typesList.Add(typeof(ISBNDBAuthor));
                    //    settings.KnownTypes = typesList;

                    //    var responseFromAPI = await streamTask;

                    //    serializer = new DataContractJsonSerializer(typeof(BookISBNSearchResult), settings);
                    //    searchResult = serializer.ReadObject(responseFromAPI) as BookISBNSearchResult;

                    //    if (searchResult == null)
                    //        return null;

                    //    if (searchResult.Data == null)
                    //        return null;

                    //    if (string.IsNullOrWhiteSpace(searchResult.Data.LongTitle))
                    //        return null;

                    //    ret = BuildBookReferenceModel(searchResult.Data);
                    //    return ret;
                    //}

                    using (var stringTask = client.GetStringAsync(_API_BASE_URL + "/book/" + isbn))
                    {
                        response = await stringTask;

                        if (string.IsNullOrWhiteSpace(response))
                            return null;

                        if (response.Contains("nable to locate"))
                            return null;

                        searchResult = JsonConvert.DeserializeObject<BookISBNSearchResult>(response);

                        if (searchResult == null)
                            return null;

                        if (searchResult.Data == null)
                            return null;

                        if (searchResult.Data.Count() != 1)
                            return null;

                        if (string.IsNullOrWhiteSpace(searchResult.Data.First().ISBN13))
                            return null;

                        ret = BuildBookReferenceModel(searchResult.Data.First());
                        return ret;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                response = null;
                serializer = null;
                searchResult = null;
                ret = null;
            }
        }

        internal static BookReferenceModel BuildBookReferenceModel(ISBNDBISBNSearchResult data)
        {
            if (!long.TryParse(data.ISBN13, out long _isbn) || _isbn <= 0)
                return null;

            BookReferenceModel ret = new BookReferenceModel
            {
                Description = data.Summary,
                ISBN = _isbn,
                Title = !string.IsNullOrWhiteSpace(data.LongTitle) ? data.LongTitle: data.ShortTitle,
                NormalizedTitle = !string.IsNullOrWhiteSpace(data.LongTitle) ? NormalizationHelper.NormalizeBookTitle(data.LongTitle) : NormalizationHelper.NormalizeBookTitle(data.ShortTitle),
                Source = Infrastructure.Enumerations.BookReferenceSources.ISBNDBAPI,
                PublisherName = data.Publisher
            };

            if (string.IsNullOrWhiteSpace(data.Language))
            {
                ret.Language = "nc";
            }
            else
            {
                switch (data.Language.Trim().ToLower())
                {
                    case "french":
                    case "fr":
                    case "francais":
                    case "français":
                        ret.Language = "fr";
                        break;
                    case "english":
                    case "en":
                        ret.Language = "fr";
                        break;
                    default:
                        ret.Language = "nc";
                        break;
                }
            }

            if (data.Authors != null && data.Authors.Count > 0)
            {
                IList<string> authorList = new List<string>();
                foreach (var author in data.Authors)
                    authorList.Add(author.Name);

                ret.AuthorNames = authorList;
                authorList = null;
            }

            if (!string.IsNullOrWhiteSpace(data.PhysicalDescription) && data.PhysicalDescription.Contains("pages"))
            {
                if (data.PhysicalDescription.Contains(';'))
                {
                    string[] sArr = data.PhysicalDescription.Split(";");
                    foreach (string s in sArr)
                    {
                        if (s.Contains("pages"))
                        {
                            string _s = s.Replace("pages", null).Trim();
                            if (Int32.TryParse(_s, out int nbPages) && nbPages > 0)
                            {
                                ret.PageCount = nbPages;
                                ret.PrintedPageCount = nbPages;
                            }
                            _s = null;
                        }
                    }
                    sArr = null;
                }
                else
                {
                    string _s = data.PhysicalDescription.Replace("pages", null).Trim();
                    if (Int32.TryParse(_s, out int nbPages) && nbPages > 0)
                    {
                        ret.PageCount = nbPages;
                        ret.PrintedPageCount = nbPages;
                    }
                    _s = null;
                }
            }

            return ret;
        }

        internal class ISBNDBAPIResponse
        {
            public ISBNDBAPIResponse()
            { }
        }

        [DataContract()]
        [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
        public class BookISBNSearchResult// : ISBNDBAPIResponse
        {
            [JsonProperty(PropertyName = "data")]
            [DataMember(Name = "data", IsRequired = true)]
            public IEnumerable<ISBNDBISBNSearchResult> Data { get; set; }

            [JsonProperty(PropertyName = "index_searched")]
            [DataMember(Name = "index_searched", IsRequired = true)]
            public string IndexSearched { get; set; }

            public BookISBNSearchResult()
            { }
        }

        [DataContract()]
        [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
        public class ISBNDBISBNSearchResult
        {
            [JsonProperty(PropertyName = "publisher_name")]
            [DataMember(Name = "publisher_name")]
            public string Publisher { get; set; }

            [JsonProperty(PropertyName = "physical_description_text")]
            [DataMember(Name = "physical_description_text")]
            public string PhysicalDescription { get; set; }

            [JsonProperty(PropertyName = "title")]
            [DataMember(Name = "title")]
            public string ShortTitle { get; set; }

            [JsonProperty(PropertyName = "title_long")]
            [DataMember(Name = "title_long")]
            public string LongTitle { get; set; }

            [JsonProperty(PropertyName = "author_data")]
            [DataMember(Name = "author_data")]
            public IList<ISBNDBAuthor> Authors { get; set; }

            [JsonProperty(PropertyName = "summary")]
            [DataMember(Name = "summary")]
            public string Summary { get; set; }

            [JsonProperty(PropertyName = "isbn10")]
            [DataMember(Name = "isbn10")]
            public string ISBN10 { get; set; }

            [JsonProperty(PropertyName = "isbn13")]
            [DataMember(Name = "isbn13")]
            public string ISBN13 { get; set; }

            [JsonProperty(PropertyName = "language")]
            [DataMember(Name = "language")]
            public string Language { get; set; }

            public ISBNDBISBNSearchResult()
            { }
        }

        [DataContract()]
        [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
        public class ISBNDBAuthor
        {
            [JsonProperty(PropertyName = "name")]
            [DataMember(Name = "name")]
            public string Name { get; set; }

            public ISBNDBAuthor()
            { }
        }
    }
}