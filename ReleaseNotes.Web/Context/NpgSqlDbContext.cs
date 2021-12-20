using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ReleaseNotes.Web.Context
{
    public class NpgSqlDbContext : IdentityDbContext<ApplicationUser>
    {
        public NpgSqlDbContext() { }
        public NpgSqlDbContext(DbContextOptions<NpgSqlDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>(role =>
            {
                role.HasData(new IdentityRole
                {
                    Name = "Usuario",
                    NormalizedName = "USUARIO"
                });
                role.HasData(new IdentityRole
                {
                    Name = "Cliente",
                    NormalizedName = "CLIENTE"
                });
                role.HasData(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
            });
        }
    }
}
