using Microsoft.AspNetCore.Identity;

namespace ReleaseNotes.IdentityServer4.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
