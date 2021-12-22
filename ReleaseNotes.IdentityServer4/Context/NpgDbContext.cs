using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReleaseNotes.IdentityServer4.Model;

namespace ReleaseNotes.IdentityServer4.Context
{
    public class NpgSqlContext : IdentityDbContext<ApplicationUser>
    {
        public NpgSqlContext() { }
        public NpgSqlContext(DbContextOptions<NpgSqlContext> options) : base(options)
        {
        }
    }
}
