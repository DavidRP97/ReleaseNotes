using System.ComponentModel.DataAnnotations;

namespace ReleaseNotes.Service.Models.PDV
{
    public class ReleasePDVViewModel
    {
        public long ReleaseId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string VersionNumber { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string VersionDate { get; set; }
        public IEnumerable<ModulePDVViewModel>? Modules { get; set; }
    }
}
