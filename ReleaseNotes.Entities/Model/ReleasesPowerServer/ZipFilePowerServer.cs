using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReleaseNotes.Entities.Model.ReleasesPowerServer
{
    public class ZipFilePowerServer
    {
        [Key]
        public long Id { get; set; }
        public string FilePath { get; set; }
        public long ReleasePowerServerId{ get; set; }
        [ForeignKey("ReleasePowerServerId")]
        public virtual ReleasePowerServer? ReleasePowerServer { get; set; }
    }
}
