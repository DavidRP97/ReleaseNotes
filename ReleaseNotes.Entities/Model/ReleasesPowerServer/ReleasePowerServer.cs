using System.ComponentModel.DataAnnotations;

namespace ReleaseNotes.Entities.Model.ReleasesPowerServer
{
    public class ReleasePowerServer
    {
        [Key]
        public long ReleaseId { get; set; }
        [Required]
        public string VersionNumber { get; set; }
        [Required]
        public string VersionDate { get; set; }
        public IEnumerable<ModulePowerServer>? Modules { get; set; }
        public IEnumerable<ZipFilePowerServer>? ZipFiles { get; set; }
    }
}
