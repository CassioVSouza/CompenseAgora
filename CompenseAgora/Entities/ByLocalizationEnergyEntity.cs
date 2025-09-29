using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompenseAgora.Entities
{
    public class ByLocalizationEnergyEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime MonthYear { get; set; }
        [ForeignKey("UnityObject")]
        public int UnityID { get; set; }
        public bool AnnualReference { get; set; }
        public DateTime WhenRegistered { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal EmissionCO2 { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Quantity { get; set; }

        public UnityEntity UnityObject { get; set; } = null!;
    }
}
