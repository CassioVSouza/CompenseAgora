using CompenseAgora.Entities;

namespace CompenseAgora.Repositories.Interfaces
{
    public interface IUnityRepository
    {
        Task<UnityEntity> GetByIdAsync(int id);
        Task<IEnumerable<UnityEntity>> GetAllAsync();
        Task<UnityEntity> AddAsync(UnityEntity entity);
        Task<UnityEntity> UpdateAsync(UnityEntity entity);
        Task DeleteAsync(int id);
    }
}
