using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseNotes.Repository.Context
{
    public class NpgSqlContext : DbContext
    {
        public NpgSqlContext() { }
        public NpgSqlContext(DbContextOptions<NpgSqlContext> options) : base(options) { }

        public DbSet<Module> Modules { get; set; }
        public DbSet<Release> Releases { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Release>().HasData(new Release
            {
                ReleaseId = 1,
                VersionNumber = "1.0"
            });
            modelBuilder.Entity<Module>(m =>
            {
                m.HasData(new Module
                {
                    ModuleId = 1,
                    ModuleName = "Comercial",
                    Title = "Vendas por pedido",
                    ReleaseId = 1,
                    Notes = "Criado novas funcionalidades"
                });
                m.HasData(new Module
                {
                    ModuleId = 2,
                    ModuleName = "Financeiro",
                    Title = "Contas a pagar",
                    ReleaseId = 1,
                    Notes = "Adicionado novos meios de pagamento",
                });
                m.HasData(new Module
                {
                    ModuleId = 3,
                    ModuleName = "Integrações",
                    Title = "Scanntech",
                    ReleaseId = 1,
                    Notes = "Implementado"
                });
            });
        }
    }
}
