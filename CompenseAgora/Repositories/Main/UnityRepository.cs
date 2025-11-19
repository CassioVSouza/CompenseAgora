using CompenseAgora.Data;
using CompenseAgora.Entities;
using CompenseAgora.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompenseAgora.Repositories.Main
{
    public class UnityRepository : IUnityRepository
    {
        private readonly DataEFContext _context;

        public UnityRepository(DataEFContext context)
        {
            _context = context;
        }

        public async Task<UnityEntity> GetByIdAsync(int id)
        {
            return await _context.Unity.FindAsync(id);
        }

        public async Task<IEnumerable<UnityEntity>> GetAllAsync()
        {
            return await _context.Unity.AsNoTracking().ToListAsync();
        }

        public async Task<UnityEntity> AddAsync(UnityEntity entity)
        {
            _context.Unity.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<UnityEntity> UpdateAsync(UnityEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Unity.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
