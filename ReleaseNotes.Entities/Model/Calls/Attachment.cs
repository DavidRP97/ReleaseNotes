using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReleaseNotes.Entities.Model.Calls
{
    public class Attachment
    {
        [Key]
        public long Id { get; set; }
        public string File { get; set; }
        public long CallId { get; set; }
        [ForeignKey("CallId")]
        public virtual Call Call { get; set; }  
    }
}
