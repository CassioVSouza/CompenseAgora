using CompenseAgora.Entities;
using CompenseAgora.Models;
using CompenseAgora.Repositories.Interfaces;
using CompenseAgora.Repositories.Main;
using CompenseAgora.Services.Interfaces;

namespace CompenseAgora.Services.Main
{
    public class EnergyByPurchaseService : IEnergyByPurchaseService
    {
        private readonly IEnergyByPurchaseRepository _repository;

        public EnergyByPurchaseService(IEnergyByPurchaseRepository repository)
        {
            _repository = repository;
        }

        public async Task AddEnergyByPurchaseAsync(EnergyByPurchaseModel model)
        {
            var entity = new ByBuyEnergyEntity
            {
                UnityID = model.UnityID,
                YearMonth = DateOnly.FromDateTime(model.YearMonth.GetValueOrDefault()),
                Font = model.Font,
                FontDescription = model.FontDescription,
                WhenRegistered = DateTime.UtcNow,
                AnnualReference = model.AnnualReference,
                EnergyTypeCode = model.EnergyTypeCode,
                TypeEnergyGasID = model.TypeEnergyGasID,
                HasEmissionFactor = model.HasEmissionFactor,
                Quantity = model.Quantity,
                EficiencyPlantGenerator = model.EficiencyPlantGenerator,
                // Os campos de emissão podem ser calculados aqui ou em outro processo
                QuantityEmissionCO2 = 0,
                QuantityEmissionCO2Biogenic = 0,
                QuantityEmissaoCO2BiogenicRemoved = 0
            };

            await _repository.AddAsync(entity);
        }
    }
}
