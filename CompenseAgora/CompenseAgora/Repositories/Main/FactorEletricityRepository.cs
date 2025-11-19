using CompenseAgora.Data;
using CompenseAgora.Entities;
using CompenseAgora.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompenseAgora.Repositories.Main
{
    public class FactorEletricityRepository : IFactorEletricityRepository
    {
        private readonly DataEFContext _context;

        public FactorEletricityRepository(DataEFContext context)
        {
            _context = context;
        }

        public async Task<FactorEletricityEntity?> GetFactorAsync(int year, int month)
        {
            return await _context.FactorEletricity
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Ano == year && f.Mes == month);
        }

        public async Task<FactorEletricityEntity?> GetAnnualFactorAsync(int year)
        {
            // Assuming month 0 represents the annual consolidated factor
            return await _context.FactorEletricity
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Ano == year && f.Mes == 0);
        }
    }
}