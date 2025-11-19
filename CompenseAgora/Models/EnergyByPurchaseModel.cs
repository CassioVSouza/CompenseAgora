using System.ComponentModel.DataAnnotations;

namespace CompenseAgora.Models
{
    public class EnergyByPurchaseModel
    {
        [Required]
        public int UnityID { get; set; }

        [Required]
        public DateTime? YearMonth { get; set; }

        [Required]
        [StringLength(50)]
        public string Font { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FontDescription { get; set; } = string.Empty;

        public bool AnnualReference { get; set; }

        [Required]
        public int EnergyTypeCode { get; set; }

        public int? TypeEnergyGasID { get; set; }

        public bool HasEmissionFactor { get; set; }

        [Required]
        [Range(0.000001, double.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public decimal Quantity { get; set; }

        [Required]
        [Range(0.000001, double.MaxValue, ErrorMessage = "A eficiência deve ser maior que zero.")]
        public decimal EficiencyPlantGenerator { get; set; }
    }
}
