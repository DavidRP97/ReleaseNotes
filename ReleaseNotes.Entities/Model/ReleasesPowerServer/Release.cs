using System.ComponentModel.DataAnnotations;

namespace ReleaseNotes.Entities.Model.ReleasesPowerServer
{
    public class Release
    {
        [Key]
        public long ReleaseId { get; set; }
        [Required]
        public string VersionNumber { get; set; }
        [Required]
        public string VersionDate { get; set; }
        [Required]
        public IEnumerable<Module> Modules { get; set; }
    }
}
