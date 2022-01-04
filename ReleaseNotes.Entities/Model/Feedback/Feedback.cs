using ReleaseNotes.Entities.Model.Calls;
using ReleaseNotes.Entities.Model.Consts;
using ReleaseNotes.Entities.Model.ReleasesPowerPDV;
using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReleaseNotes.Entities.Model.Feedback
{
    public class ReleasesFeedback
    {
        [Key]
        public long FeedbackId { get; set; }
        public string? FeedbackDate { get; set; }
        public FeedbackFrom FeedbackFrom { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        [StringLength(300)]
        public string? Details { get; set; }
        [Required]
        public bool FeedbackPositive { get; set; }
        [Required]
        public bool OpenCall { get; set; }        
        public long? CallId { get; set; }
        [ForeignKey("CallId")]
        public virtual Call? Call { get; set; }
        public long? ModulePdvId { get; set; }
        [ForeignKey("ModulePdvId")]
        public virtual ModulePDV ModulePDV { get; set; }
        public long? ModulePowerServerId { get; set; }
        [ForeignKey("ModulePowerServerId")]
        public virtual ModulePowerServer ModulePowerServer { get; set; }
    }
}
