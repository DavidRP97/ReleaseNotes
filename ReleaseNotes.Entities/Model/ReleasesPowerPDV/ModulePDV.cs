using ReleaseNotes.Entities.Model.Feedback;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReleaseNotes.Entities.Model.ReleasesPowerPDV
{
    public class ModulePDV
    {
        [Key]
        public long ModuleId { get; set; }
        [Required]
        [StringLength(50)]
        public string ModuleName { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string Notes { get; set; }
        [ForeignKey("ReleaseId")]
        public virtual ReleasePDV? Release { get; set; }
        public long ReleaseId { get; set; }
        public IEnumerable<ReleasesFeedback> Feedbacks { get; set; }
    }
}
