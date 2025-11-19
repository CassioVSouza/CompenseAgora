using CompenseAgora.Entities;
using CompenseAgora.Models;

namespace CompenseAgora.Services.Interfaces
{
    public interface IUnityService
    {
        Task<UnityModel> GetByIdAsync(int id);
        Task<IEnumerable<UnityModel>> GetAllAsync();
        Task<List<UnityEntity>> GetUnitsAsync(); // Existing method
        Task<UnityModel> AddAsync(UnityModel model);
        Task<UnityModel> UpdateAsync(UnityModel model);
        Task DeleteAsync(int id);
    }
}
