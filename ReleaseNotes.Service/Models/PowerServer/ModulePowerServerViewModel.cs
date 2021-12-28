using ReleaseNotes.Service.Models.Feedback;

namespace ReleaseNotes.Service.PowerServer.Models
{
    public class ModulePowerServerViewModel
    {
        public long ModuleId { get; set; }
        public string ModuleName { get; set; }
        public long ReleaseId { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public IEnumerable<FeedbackViewModel>? Feedbacks { get; set; }
    }
}
