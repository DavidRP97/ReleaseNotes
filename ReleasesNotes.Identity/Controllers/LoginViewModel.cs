using System.ComponentModel.DataAnnotations;

namespace ReleaseNotes.Identity.Controllers
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Insira um {0}")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira uma {0}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
