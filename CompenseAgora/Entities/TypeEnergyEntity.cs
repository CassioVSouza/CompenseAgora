using System.ComponentModel.DataAnnotations;

namespace CompenseAgora.Entities
{
    public class TypeEnergyEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
