using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompenseAgora.Entities
{
    public class SolarEnergyEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UnityObject")]
        public int UnityID { get; set; }
        public DateOnly MonthYear { get; set; }
        [StringLength(50)]
        public string Font { get; set; } = null!;
        [StringLength(50)]
        public string DescriptionFont { get; set; } = string.Empty;
        public bool AnnualReference { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal QuantityGenerated { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal QuantityConsumed { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal QuantityEmissaoCO2 { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal QuantityEmissionCO2Biogenic { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal QuantityEmissionCO2BiogenicRemoved { get; set; }

        public UnityEntity UnityObject { get; set; } = null!;
    }
}
