using System.ComponentModel.DataAnnotations;

namespace CompenseAgora.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Password { get; set; } = string.Empty;
    }
}
