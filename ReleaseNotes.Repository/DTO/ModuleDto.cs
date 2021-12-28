namespace ReleaseNotes.Repository.DTO
{
    public class ModuleDto
    {
        public long ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public long ReleaseId { get; set; }
        public IEnumerable<FeedbackDto>? Feedbacks { get; set; }
    }
}
