using CompenseAgora.Entities;

namespace CompenseAgora.Repositories.Interfaces
{
    public interface IEnergyByPurchaseRepository
    {
        Task<ByBuyEnergyEntity> AddAsync(ByBuyEnergyEntity entity);
    }
}
