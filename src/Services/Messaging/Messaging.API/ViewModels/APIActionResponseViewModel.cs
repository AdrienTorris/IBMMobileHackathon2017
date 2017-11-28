namespace IBM.Books.Messaging.API.ViewModels
{
    public class APIActionResponseViewModel : APIResponseBaseViewModel
    {
        public APIActionResponseViewModel()
            : base()
        { }

        public APIActionResponseViewModel(string errorCode, string errorMessage)
            : base(errorCode, errorMessage)
        { }
    }
}