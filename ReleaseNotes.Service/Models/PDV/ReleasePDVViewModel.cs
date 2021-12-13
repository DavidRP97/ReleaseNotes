namespace ReleaseNotes.Service.Models.PDV
{
    public class ReleasePDVViewModel
    {
        public long ReleaseId { get; set; }
        public string VersionNumber { get; set; }
        public IEnumerable<ModulePDVViewModel> Modules { get; set; }
    }
}
