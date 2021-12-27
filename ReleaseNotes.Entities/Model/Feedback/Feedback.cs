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
        public FeedbackFrom FeedbackFrom { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        [StringLength(300)]
        public string Details { get; set; }
        [Required]
        public bool FeedbackPositive { get; set; }
        public long? ModulePowerServerId { get; set; }
        public long? ModulePdvId { get; set; }
        [ForeignKey("ModulePdvId")]
        public ModulePDV? ModulePDV { get; set; }
        [ForeignKey("ModulePowerServerId")]
        public Module? ModulePowerServer { get; set; }
    }
}
