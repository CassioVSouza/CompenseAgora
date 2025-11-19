using CompenseAgora.Entities;

namespace CompenseAgora.Repositories.Interfaces
{
    public interface ISolarEnergyRepository
    {
        Task<SolarEnergyEntity> GetById(int id);
        Task<IEnumerable<SolarEnergyEntity>> GetAll();
        Task<SolarEnergyEntity> Add(SolarEnergyEntity entity);
        Task<SolarEnergyEntity> Update(SolarEnergyEntity entity);
        Task Delete(int id);
    }
}