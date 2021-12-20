using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Identity.Context;

namespace ReleasesNote.Identity.Context
{
    public class NpgSqlContext : IdentityDbContext<ApplicationUser>
    {
        public NpgSqlContext() { }
        public NpgSqlContext(DbContextOptions<NpgSqlContext> options) : base(options) { }

    }
}
