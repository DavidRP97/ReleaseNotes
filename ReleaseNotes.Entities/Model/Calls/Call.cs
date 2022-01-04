using ReleaseNotes.Entities.Model.Consts;
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
        public virtual ReleasesFeedback? Feedback { get; set; }
        public bool IsUrgent { get; set; }
        public Priority PriorityDegree { get; set; }
        public Status Status { get; set; }
        public FeedbackFrom Software { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Detail { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
    }
}
