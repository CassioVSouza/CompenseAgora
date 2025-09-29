using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompenseAgora.Entities
{
    public class TypeEnergyGasEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60)]
        public string Name { get; set; } = string.Empty;
        [ForeignKey("TypeEnergyObject")]
        public int TypeEnergyID { get; set; }

        public TypeEnergyEntity TypeEnergyObject { get; set; } = null!;
    }
}
