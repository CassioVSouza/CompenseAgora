using System.ComponentModel.DataAnnotations;

namespace CompenseAgora.Models
{
    public class SolarEnergyModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Unidade é obrigatório.")]
        public int UnityID { get; set; }

        [Required(ErrorMessage = "O campo Mês/Ano é obrigatório.")]
        public DateOnly MonthYear { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required(ErrorMessage = "O campo Fonte é obrigatório.")]
        [StringLength(50)]
        public string Font { get; set; } = "Solar Fotovoltaica";

        [StringLength(50)]
        public string DescriptionFont { get; set; } = string.Empty;

        public bool AnnualReference { get; set; }

        [Required(ErrorMessage = "O campo Quantidade Gerada é obrigatório.")]
        [Range(0.000001, double.MaxValue, ErrorMessage = "A Quantidade Gerada deve ser maior que zero.")]
        public decimal QuantityGenerated { get; set; }

        [Required(ErrorMessage = "O campo Quantidade Consumida é obrigatório.")]
        [Range(0.000001, double.MaxValue, ErrorMessage = "A Quantidade Consumida deve ser maior que zero.")]
        public decimal QuantityConsumed { get; set; }
        
        public string? UnityName { get; set; }
        public decimal? CO2 { get; set; }
    }
}