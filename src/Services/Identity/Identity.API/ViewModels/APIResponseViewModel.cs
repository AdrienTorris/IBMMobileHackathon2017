using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM.Books.Identity.API.ViewModels
{
    public class APIResponseViewModel
    {
        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public APIResponseContentSection Content { get; set; }

        public APIResponseViewModel()
        { }

        public APIResponseViewModel(string errorCode, string errorMsg)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMsg;
        }

        public APIResponseViewModel(string contentSectionName, IAPIResponseContent content)
        {
            Content = new APIResponseContentSection(contentSectionName, content);
        }
    }

    public class APIResponseContentSection
    {
        public string Name { get; set; }

        public IAPIResponseContent Content { get; set; }

        public APIResponseContentSection(string name, IAPIResponseContent content)
        {
            Name = name;
            Content = content;
        }
    }

    public interface IAPIResponseContent
    {

    }

    public class UserDetailsViewModel : IAPIResponseContent
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}