namespace IBM.Books.Identity.API.Model
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}