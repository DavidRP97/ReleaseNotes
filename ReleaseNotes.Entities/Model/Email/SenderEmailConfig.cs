using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReleaseNotes.Entities.Model.Email
{
    public class SenderEmailConfig
    {
        [Key]
        public long SenderConfigId { get; set; }  
        public virtual Sender? Sender { get; set; }
        public ICollection<Receiver>? Receivers { get; set; }
    }
}
