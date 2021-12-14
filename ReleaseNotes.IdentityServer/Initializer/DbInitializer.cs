using IdentityModel;
using Microsoft.AspNetCore.Identity;
using ReleaseNotes.IdentityServer.Config;
using ReleaseNotes.IdentityServer.Context;
using ReleaseNotes.IdentityServer.Model;
using System.Security.Claims;

namespace ReleaseNotes.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly NpgSqlContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(NpgSqlContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(IdentityConfig.SuperControleAdmin).Result != null) return;
            _roleManager.CreateAsync(new IdentityRole(IdentityConfig.SuperControleAdmin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(IdentityConfig.Client)).GetAwaiter().GetResult();

            ApplicationUser client = new ApplicationUser()
            {
                UserName = "supercontrole",
                Email = "desenvolvimento04@supercontrole.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (15) 99685-7507",
                FirstName = "David",
                LastName = "Paulino"
            };
            _userManager.CreateAsync(client, "SuperControle@2007").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(client, IdentityConfig.SuperControleAdmin).GetAwaiter().GetResult();

            var adminClaims = _userManager.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfig.SuperControleAdmin)
            }).Result;
        }
    }
}
