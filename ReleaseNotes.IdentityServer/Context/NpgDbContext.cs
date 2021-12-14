using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReleaseNotes.IdentityServer.Model;

namespace ReleaseNotes.IdentityServer.Context
{
    public class NpgSqlContext : IdentityDbContext<ApplicationUser>
    {
        public NpgSqlContext() { }
        public NpgSqlContext(DbContextOptions<NpgSqlContext> options) : base(options)
        {
        }
    }
}
