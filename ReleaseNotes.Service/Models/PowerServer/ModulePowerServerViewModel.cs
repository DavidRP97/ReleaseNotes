using ReleaseNotes.Service.Models.Feedback;
using System.ComponentModel.DataAnnotations;

namespace ReleaseNotes.Service.PowerServer.Models
{
    public class ModulePowerServerViewModel
    {
        public long ModuleId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string ModuleName { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public long ReleaseId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Notes { get; set; }
        public IEnumerable<FeedbackViewModel>? Feedbacks { get; set; }
    }
}
