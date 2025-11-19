using CompenseAgora.Data;
using CompenseAgora.Entities;
using CompenseAgora.Repositories.Interfaces;

namespace CompenseAgora.Repositories.Main
{
    public class EnergyByPurchaseRepository : IEnergyByPurchaseRepository
    {
        private readonly DataEFContext _context;

        public EnergyByPurchaseRepository(DataEFContext context)
        {
            _context = context;
        }

        public async Task<ByBuyEnergyEntity> AddAsync(ByBuyEnergyEntity entity)
        {
            _context.PurchaseEnergy.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
