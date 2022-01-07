using ReleaseNotes.Service.Models.Feedback;
using System.ComponentModel.DataAnnotations;

namespace ReleaseNotes.Service.Models.PDV
{
    public class ModulePDVViewModel
    {
        public long ModuleId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string ModuleName { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Notes { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public long ReleaseId { get; set; }
        public IEnumerable<FeedbackViewModel>? Feedbacks { get; set; }
    }
}
