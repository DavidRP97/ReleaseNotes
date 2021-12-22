using Microsoft.AspNetCore.Identity;
using ReleaseNotes.Entities.Model.Consts;

namespace ReleaseNotes.Repository.Context
{
    public  class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool FirstAccess { get; set; }
        public StatusConta Status { get; set; }
    }
}
