using CompenseAgora.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompenseAgora.Data
{
    public class DataEFContext : DbContext
    {
        public DataEFContext(DbContextOptions<DataEFContext> options) : base(options) { }
         
        public DbSet<ByBuyEnergyEntity> PurchaseEnergy { get; set; }
        public DbSet<ByLocalizationEnergyEntity> LocalizationEnergy { get; set; }
        public DbSet<ProfileEntity> Profile { get; set; }
        public DbSet<SolarEnergyEntity> SolarEnergy { get; set; }
        public DbSet<TypeEnergyEntity> TypeEnergy { get; set; }
        public DbSet<TypeEnergyGasEntity> TypeEnergyGas { get; set; }
        public DbSet<UnityEntity> Unity { get; set; }
    }
}
