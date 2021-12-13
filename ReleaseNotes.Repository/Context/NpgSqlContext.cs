﻿using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Entities.Model.ReleasesPowerPDV;
using ReleaseNotes.Entities.Model.ReleasesPowerServer;

namespace ReleaseNotes.Repository.Context
{
    public class NpgSqlContext : DbContext
    {
        public NpgSqlContext() { }
        public NpgSqlContext(DbContextOptions<NpgSqlContext> options) : base(options) { }


        //PDV
        public DbSet<ReleasePDV> ReleasePDVs { get; set; }
        public DbSet<ModulePDV> ModulePDVs { get; set; }   
        
        //POWERSERVER
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
            modelBuilder.Entity<Release>().HasData(new Release
            {
                ReleaseId = 2,
                VersionNumber = "2.0"
            });
            modelBuilder.Entity<Module>(m =>
            {
                m.HasData(new Module
                {
                    ModuleId = 4,
                    ModuleName = "Fiscal",
                    Title = "NF Entrada",
                    ReleaseId = 2,
                    Notes = "Correção na emissão"
                });
                m.HasData(new Module
                {
                    ModuleId = 5,
                    ModuleName = "Financeiro",
                    Title = "Contas a receber",
                    ReleaseId = 2,
                    Notes = "Corrigido Bug",
                });
            });
            modelBuilder.Entity<ReleasePDV>().HasData(new ReleasePDV
            {
                ReleaseId = 1,
                VersionNumber = "1.0"
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
                    Notes = "Adicionado novos meios de pagamento",
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
