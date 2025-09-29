using System.ComponentModel.DataAnnotations;

namespace CompenseAgora.Entities
{
    public class ProfileEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60)]
        public string Name { get; set; } = string.Empty;
        [StringLength(60)]
        public string SecondName { get; set; } = string.Empty;
    }
}
