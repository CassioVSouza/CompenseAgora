using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompenseAgora.Entities
{
    public class ByBuyEnergyEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UnityObject")]
        public int UnityID { get; set; }
        public DateOnly YearMonth { get; set; }
        [StringLength(50)]
        public string Font { get; set; } = null!;
        [StringLength(50)]
        public string FontDescription { get; set; } = null!;
        public DateTime WhenRegistered { get; set; }
        public bool AnnualReference { get; set; }
        [ForeignKey("TypeEnergyObject")]
        public int EnergyTypeCode { get; set; }
        [ForeignKey("TypeEnergyGasObject")]
        public int? TypeEnergyGasID { get; set; }
        public bool HasEmissionFactor { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal EficiencyPlantGenerator { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal QuantityEmissionCO2 { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal QuantityEmissionCO2Biogenic { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal QuantityEmissaoCO2BiogenicRemoved { get; set; }

        public UnityEntity UnityObject { get; set; } = null!;
        public TypeEnergyEntity TypeEnergyObject { get; set; } = null!;
        public TypeEnergyGasEntity TypeEnergyGasObject { get; set; } = null!;

    }
}
