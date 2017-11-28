namespace IBM.Books.Catalog.API.Infrastructure.Helpers
{
    using System;

    internal static class NormalizationHelper
    {
        public static string NormalizeBookTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));

            return CleanAccents(title).Trim().ToUpper();
        }

        public static string NormalizePublisherName(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));

            return CleanAccents(title).Trim().ToUpper();
        }

        public static string NormalizeAuthorName(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentNullException(nameof(author));

            return CleanAccents(author).Trim().ToUpper();
        }

        internal static string CleanAccents(string s) =>
             s.Replace('é', 'e').Replace('è', 'e').Replace('à', 'a').Replace('ê', 'e').Replace('î', 'i').Replace('#', '-').Replace('ù', 'u');
    }
}