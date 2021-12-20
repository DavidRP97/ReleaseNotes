using Microsoft.AspNetCore.Identity;
using ReleaseNotes.Web.Context;

namespace ReleaseNotes.Web.Repository
{
    public class User : IUser
    {
        private readonly NpgSqlDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public User(NpgSqlDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser> GetUserByEmail(string email) => await _userManager.FindByEmailAsync(email);
        public async Task<ApplicationUser> GetUserByUserName(string name) => await _userManager.FindByNameAsync(name);

        public async Task LoginUser(ApplicationUser user, bool remember) => await _signInManager.SignInAsync(user, remember);   

        public int VerifyRegister()
        {
            return  _context.Users.Count();
        }
    }
}
