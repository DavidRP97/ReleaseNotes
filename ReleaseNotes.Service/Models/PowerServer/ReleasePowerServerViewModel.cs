using System.ComponentModel.DataAnnotations;

namespace ReleaseNotes.Service.PowerServer.Models
{
    public class ReleasePowerServerViewModel
    {
        public long ReleaseId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string VersionNumber { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string VersionDate { get; set; }
        public IEnumerable<ModulePowerServerViewModel>? Modules { get; set; }
    }
}
