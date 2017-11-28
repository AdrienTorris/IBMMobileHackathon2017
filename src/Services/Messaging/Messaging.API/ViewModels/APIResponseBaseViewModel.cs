namespace IBM.Books.Messaging.API.ViewModels
{
    public class APIResponseBaseViewModel
    {
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }

        public APIResponseBaseViewModel()
        { }

        public APIResponseBaseViewModel(string errorCode, string errorMessage)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
    }
}