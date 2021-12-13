using System.ComponentModel.DataAnnotations;

namespace ReleaseNotes.Entities.Model.ReleasesPowerPDV
{
    public class ReleasePDV
    {
        [Key]
        public long ReleaseId { get; set; }
        [Required]
        public string VersionNumber { get; set; }
        [Required]
        public IEnumerable<ModulePDV> Modules { get; set; }
    }
}
