using CompenseAgora.Entities;

namespace CompenseAgora.Repositories.Interfaces
{
    public interface IFactorEletricityRepository
    {
        Task<FactorEletricityEntity?> GetFactorAsync(int year, int month);
        Task<FactorEletricityEntity?> GetAnnualFactorAsync(int year);
    }
}