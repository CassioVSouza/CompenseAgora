using System.ComponentModel.DataAnnotations;

namespace CompenseAgora.Models
{
    public class UnityModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da unidade é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome não pode exceder 50 caracteres.")]
        public string Name { get; set; } = string.Empty;
    }
}