using ReleaseNotes.Entities.Model.Consts;

namespace ReleaseNotes.Repository.DTO
{
    public class FeedbackDto
    {
        public long FeedbackId { get; set; }
        public string? FeedbackDate { get; set; }
        public FeedbackFrom FeedbackFrom { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Details { get; set; }
        public bool FeedbackPositive { get; set; }
        public bool OpenCall { get; set; }
        public long? CallId { get; set; }
        public long? ModulePowerServerId { get; set; }
        public long? ModulePdvId { get; set; }
    }
}
