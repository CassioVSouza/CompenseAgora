using CompenseAgora.Entities;
using CompenseAgora.Models;
using CompenseAgora.Repositories.Interfaces;
using CompenseAgora.Services.Interfaces;

namespace CompenseAgora.Services.Main
{
    public class UnityService : IUnityService
    {
        private readonly IUnityRepository _repository;

        public UnityService(IUnityRepository repository)
        {
            _repository = repository;
        }

        public async Task<UnityModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return MapToModel(entity);
        }

        public async Task<IEnumerable<UnityModel>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToModel);
        }

        public async Task<List<UnityEntity>> GetUnitsAsync()
        {
            // Assuming this method is used for dropdowns, returning entities might be intended.
            return (await _repository.GetAllAsync()).ToList();
        }

        public async Task<UnityModel> AddAsync(UnityModel model)
        {
            var entity = MapToEntity(model);
            var newEntity = await _repository.AddAsync(entity);
            return MapToModel(newEntity);
        }

        public async Task<UnityModel> UpdateAsync(UnityModel model)
        {
            var entity = await _repository.GetByIdAsync(model.Id);
            if (entity != null)
            {
                entity.Name = model.Name;
                var updatedEntity = await _repository.UpdateAsync(entity);
                return MapToModel(updatedEntity);
            }
            return null;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Mappers
        private UnityModel MapToModel(UnityEntity entity)
        {
            if (entity == null) return null;
            return new UnityModel { Id = entity.Id, Name = entity.Name };
        }

        private UnityEntity MapToEntity(UnityModel model)
        {
            if (model == null) return null;
            return new UnityEntity { Id = model.Id, Name = model.Name };
        }
    }
}
