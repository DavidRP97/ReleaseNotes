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
        public DbSet<Attachment> Attachments { get; set; }  

        //EMAIL
        public DbSet<SenderEmailConfig> SenderEmailConfig { get; set; }
        public DbSet<Receiver> Receivers { get; set; }
        public DbSet<Sender> Senders { get; set; }
           
    }
}
