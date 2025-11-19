using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompenseAgora.Entities
{
    public class FactorEletricityEntity
    {
        [Key]
        public int Codigo { get; set; }
        public short Mes { get; set; }
        public short Ano { get; set; }
        [Column(TypeName = "Decimal(18, 8)")]
        public decimal feSIN { get; set; }
    }
}
