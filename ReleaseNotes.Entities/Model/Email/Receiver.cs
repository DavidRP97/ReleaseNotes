using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReleaseNotes.Entities.Model.Email
{
    public class Receiver
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }        
        public SenderEmailConfig? SenderEmailConfig { get; set; }
        [ForeignKey("SenderEmailConfig")]
        public long SenderEmailConfigId { get; set; }
    }
}
