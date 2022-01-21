using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Entities.Model.Calls;
using ReleaseNotes.Entities.Model.Consts;
using ReleaseNotes.Entities.Model.Email;
using ReleaseNotes.Entities.Model.Feedback;
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
        public DbSet<ZipFilePdv> ZipFilesPdv { get; set;}

        //POWERSERVER
        public DbSet<ModulePowerServer> Modules { get; set; }
        public DbSet<ReleasePowerServer> Releases { get; set; }
        public DbSet<ZipFilePowerServer> ZipFilesPowerServer { get; set; }

        //FEEDBACK
        public DbSet<ReleasesFeedback> Feedbacks { get; set; }

        //CALL
        public DbSet<Call> Calls { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        //EMAIL
        public DbSet<SenderEmailConfig> SenderEmailConfig { get; set; }
        public DbSet<Receiver> Receivers { get; set; }
        public DbSet<Sender> Senders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SenderEmailConfig>().HasData(new SenderEmailConfig
            {
                SenderConfigId = 1
            });
            modelBuilder.Entity<Receiver>(r =>
            {
                r.HasData(new Receiver
                {
                    Id = 1,
                    SenderEmailConfigId = 1,
                    Name = "David Rodrigues",
                    Email = "d.rodrigues0505@gmail.com"
                });
                r.HasData(new Receiver
                {
                    Id = 2,
                    SenderEmailConfigId = 1,
                    Name = "Rogério Trevisan",
                    Email = "analise@supercontrole.com"
                });
            });
            modelBuilder.Entity<Sender>().HasData(new Sender
            {
                Id = 1,
                SenderEmailConfigId = 1,
                Email = "desenvolvimento04@supercontrole.com",
                Name = "SuperControle Chamados"
            });
        }

    }
}
