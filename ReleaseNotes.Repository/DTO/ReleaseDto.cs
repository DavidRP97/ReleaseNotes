namespace ReleaseNotes.Repository.DTO
{
    public class ReleaseDto
    {
        public long ReleaseId { get; set; }
        public string VersionDate { get; set; }
        public string VersionNumber { get; set; }
        public IEnumerable<ModuleDto>? Modules { get; set; }
    }
}
