using System.ComponentModel.DataAnnotations;

namespace ReleaseNotes.Web.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [StringLength(16, ErrorMessage = "Use menos caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "O campo Primeiro Nome é obrigatório")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "O campo Sobrenome é obrigatório")]
        public string LastName { get; set; }
       
    }
}
