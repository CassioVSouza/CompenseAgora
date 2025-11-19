using CompenseAgora.Models;

namespace CompenseAgora.Services.Interfaces
{
    public interface IEnergyByPurchaseService
    {
        Task AddEnergyByPurchaseAsync(EnergyByPurchaseModel model);
    }
}
