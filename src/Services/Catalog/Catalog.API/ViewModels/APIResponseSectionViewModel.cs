namespace IBM.Books.Catalog.API.ViewModels
{
    using IBM.Books.Catalog.API.Infrastructure.Enumerations;
    using System.Collections.Generic;

    public class APIResponseSectionViewModel
    {
        public string Name { get; set; }
        public IList<IContent> Content { get; set; }

        public APIResponseSectionViewModel()
        { }

        public APIResponseSectionViewModel(string name, IContent content)
        {
            Name = name;
            Content = new List<IContent>();
            Content.Add(content);
        }

        public APIResponseSectionViewModel(APIResponseContentSections section, IContent content)
        {
            Name = section.ToString();
            Content = new List<IContent>();
            Content.Add(content);
        }
    }
}