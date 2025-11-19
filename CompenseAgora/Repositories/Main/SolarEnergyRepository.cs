using CompenseAgora.Data;
using CompenseAgora.Entities;
using CompenseAgora.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompenseAgora.Repositories.Main
{
    public class SolarEnergyRepository : ISolarEnergyRepository
    {
        private readonly DataEFContext _context;

        public SolarEnergyRepository(DataEFContext context)
        {
            _context = context;
        }

        public async Task<SolarEnergyEntity> GetById(int id)
        {
            return await _context.SolarEnergy.FindAsync(id);
        }

        public async Task<IEnumerable<SolarEnergyEntity>> GetAll()
        {
            return await _context.SolarEnergy.Include(s => s.UnityObject).AsNoTracking().ToListAsync();
        }

        public async Task<SolarEnergyEntity> Add(SolarEnergyEntity entity)
        {
            _context.SolarEnergy.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SolarEnergyEntity> Update(SolarEnergyEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _context.SolarEnergy.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}