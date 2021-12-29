using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Entities.Model.Calls;
using ReleaseNotes.Entities.Model.Consts;
using ReleaseNotes.Entities.Model.Feedback;
using ReleaseNotes.Entities.Model.ReleasesPowerPDV;
using ReleaseNotes.Entities.Model.ReleasesPowerServer;

namespace ReleaseNotes.Repository.Context
{
    public class NpgSqlContext : IdentityDbContext<ApplicationUser>
    {
        public NpgSqlContext() { }
        public NpgSqlContext(DbContextOptions<NpgSqlContext> options) : base(options) { }


        //PDV
        public DbSet<ReleasePDV> ReleasePDVs { get; set; }
        public DbSet<ModulePDV> ModulePDVs { get; set; }

        //POWERSERVER
        public DbSet<ModulePowerServer> Modules { get; set; }
        public DbSet<ReleasePowerServer> Releases { get; set; }

        //FEEDBACK
        public DbSet<ReleasesFeedback> Feedbacks { get; set; }

        //CALL
        public DbSet<Call> Calls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReleasePowerServer>().HasData(new ReleasePowerServer
            {
                ReleaseId = 1,
                VersionNumber = "1.0",
                VersionDate = DateTime.Now.ToShortDateString()
            });
            modelBuilder.Entity<ModulePowerServer>(m =>
            {
                m.HasData(new ModulePowerServer
                {
                    ModuleId = 1,
                    ModuleName = "Comercial",
                    Title = "Vendas por pedido",
                    ReleaseId = 1,
                    Notes = "Criado novas funcionalidades"
                });
                m.HasData(new ModulePowerServer
                {
                    ModuleId = 2,
                    ModuleName = "Financeiro",
                    Title = "Contas a pagar",
                    ReleaseId = 1,
                    Notes = "Adicionado novos meios de pagamento"
                });
                m.HasData(new ModulePowerServer
                {
                    ModuleId = 3,
                    ModuleName = "Integrações",
                    Title = "Scanntech",
                    ReleaseId = 1,
                    Notes = "Implementado"
                });
            });
            modelBuilder.Entity<ReleasePowerServer>().HasData(new ReleasePowerServer
            {
                ReleaseId = 2,
                VersionNumber = "2.0",
                VersionDate = DateTime.Now.ToShortDateString()
            });
            modelBuilder.Entity<ModulePowerServer>(m =>
            {
                m.HasData(new ModulePowerServer
                {
                    ModuleId = 4,
                    ModuleName = "Fiscal",
                    Title = "NF Entrada",
                    ReleaseId = 2,
                    Notes = "Correção na emissão"
                });
                m.HasData(new ModulePowerServer
                {
                    ModuleId = 5,
                    ModuleName = "Financeiro",
                    Title = "Contas a receber",
                    ReleaseId = 2,
                    Notes = "Corrigido Bug"
                });
            });
            modelBuilder.Entity<ReleasePDV>().HasData(new ReleasePDV
            {
                ReleaseId = 1,
                VersionNumber = "1.0",
                VersionDate = DateTime.Now.ToShortDateString()
            });
            modelBuilder.Entity<ModulePDV>(m =>
            {
                m.HasData(new ModulePDV
                {
                    ModuleId = 1,
                    ModuleName = "Comercial",
                    Title = "Vendas por pedido",
                    ReleaseId = 1,
                    Notes = "Criado novas funcionalidades"
                });
                m.HasData(new ModulePDV
                {
                    ModuleId = 2,
                    ModuleName = "Financeiro",
                    Title = "Contas a pagar",
                    ReleaseId = 1,
                    Notes = "Adicionado novos meios de pagamento"
                });
                m.HasData(new ModulePDV
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
