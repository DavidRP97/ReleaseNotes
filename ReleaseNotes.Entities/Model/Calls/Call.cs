using ReleaseNotes.Entities.Model.Feedback;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReleaseNotes.Entities.Model.Calls
{
    public class Call
    {
        [Key]
        public long CallId { get; set; }
        public long? FeedbackId { get; set; }
        [ForeignKey("FeedbackId")]
        public ReleasesFeedback? Feedback { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Detail { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
    }
}
