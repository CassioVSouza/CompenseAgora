using CompenseAgora.Models;

namespace CompenseAgora.Services.Interfaces
{
    public interface ISolarEnergyService
    {
        Task<SolarEnergyModel> GetById(int id);
        Task<IEnumerable<SolarEnergyModel>> GetAll();
        Task<SolarEnergyModel> Add(SolarEnergyModel model);
        Task<SolarEnergyModel> Update(SolarEnergyModel model);
        Task Delete(int id);
    }
}