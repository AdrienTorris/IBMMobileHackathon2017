namespace IBM.Books.Catalog.API.ViewModels
{
    using System.Collections.Generic;

    public class APIContentResponseViewModel : APIResponseBaseViewModel
    {
        public IList<APIResponseSectionViewModel> Sections { get; set; }

        public APIContentResponseViewModel()
            : base()
        { }

        public APIContentResponseViewModel(string errorCode, string errorMessage)
            : base(errorCode, errorMessage)
        { }

        public APIContentResponseViewModel(APIResponseSectionViewModel section)
            : base()
        {
            Sections = new List<APIResponseSectionViewModel>();
            Sections.Add(section);
        }

        public void AddSection(APIResponseSectionViewModel section)
        {
            if (this.Sections == null)
                this.Sections = new List<APIResponseSectionViewModel>();

            this.Sections.Add(section);
        }
    }
}