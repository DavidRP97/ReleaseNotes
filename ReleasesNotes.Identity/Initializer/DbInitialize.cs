using Microsoft.AspNetCore.Identity;
using ReleaseNotes.Identity.Context;

namespace ReleaseNote.Identity.Initializer
{
    public class DbInitialize : IDbInitialize
    {
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitialize(UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _role = role;
            _user = user;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync("Admin").Result != null) return;
            _role.CreateAsync(new IdentityRole(
                "Admin")).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "desenvolvimento04@supercontrole.com",
                Email = "desenvolvimento04@supercontrole.com",
                FullName = "SuperControleAdmin"
            };
            _user.CreateAsync(admin, "SuperControle@2007").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, "Admin");
            
        }
    }
}
