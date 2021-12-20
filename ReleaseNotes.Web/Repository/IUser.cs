using ReleaseNotes.Web.Context;

namespace ReleaseNotes.Web.Repository
{
    public interface IUser
    {
        public int VerifyRegister();
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<ApplicationUser> GetUserByUserName(string name);
        
        Task LoginUser(ApplicationUser user, bool remember);
    }
}
