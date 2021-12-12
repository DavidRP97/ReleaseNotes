namespace ReleaseNotes.Service.PowerServer.Models
{
    public class ReleasePowerServerViewModel
    {
        public long ReleaseId { get; set; }
        public string VersionNumber { get; set; }
        public IEnumerable<ModulePowerServerViewModel> Modules { get; set; }
    }
}
