using IdentityModel;
using Microsoft.AspNetCore.Identity;
using ReleaseNotes.IdentityServer4.Config;
using ReleaseNotes.IdentityServer4.Context;
using ReleaseNotes.IdentityServer4.Model;
using System.Security.Claims;

namespace ReleaseNotes.IdentityServer4.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly NpgSqlContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(NpgSqlContext context,
            UserManager<ApplicationUser> user,
            RoleManager<IdentityRole> role)
        {
            _context = context;
            _userManager = user;
            _roleManager = role;
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(IdentityConfig.SuperControleAdmin).Result != null) return;
            _roleManager.CreateAsync(new IdentityRole(IdentityConfig.SuperControleAdmin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(IdentityConfig.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "supercontrole",
                Email = "desenvolvimento04@supercontrole.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (15) 99685-7507",
                FirstName = "David",
                LastName = "Paulino"
            };
            _userManager.CreateAsync(admin, "SuperControle@2007").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(admin, IdentityConfig.SuperControleAdmin).GetAwaiter().GetResult();

            var adminClaims = _userManager.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.Email, admin.Email),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfig.SuperControleAdmin)
            }).Result;
        }
    }
}
