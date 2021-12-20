using Microsoft.AspNetCore.Identity;

namespace ReleaseNotes.Identity.Context
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
