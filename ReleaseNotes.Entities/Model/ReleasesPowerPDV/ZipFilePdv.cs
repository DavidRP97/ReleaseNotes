using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReleaseNotes.Entities.Model.ReleasesPowerPDV
{
    public class ZipFilePdv
    {
        [Key]
        public long Id { get; set; }
        public string FilePath { get; set; }
        public long ReleasePdvId { get; set; }
        [ForeignKey("ReleasePdvId")]
        public virtual ReleasePDV? ReleasePDV { get; set; }
    }
}
