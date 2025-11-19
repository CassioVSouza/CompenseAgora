using CompenseAgora.Entities;
using CompenseAgora.Models;
using CompenseAgora.Repositories.Interfaces;
using CompenseAgora.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace CompenseAgora.Services.Main
{
    public class SolarEnergyService : ISolarEnergyService
    {
        private readonly ISolarEnergyRepository _repository;
        private readonly IFactorEletricityRepository _factorRepository;
        private readonly ILogger<SolarEnergyService> _logger;

        public SolarEnergyService(ISolarEnergyRepository repository, IFactorEletricityRepository factorRepository, ILogger<SolarEnergyService> logger)
        {
            _repository = repository;
            _factorRepository = factorRepository;
            _logger = logger;
        }

        public async Task<SolarEnergyModel> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            return MapToModel(entity);
        }

        public async Task<IEnumerable<SolarEnergyModel>> GetAll()
        {
            var entities = await _repository.GetAll();
            return entities.Select(MapToModel);
        }

        public async Task<SolarEnergyModel> Add(SolarEnergyModel model)
        {
            var entity = MapToEntity(model);
            
            await CalculateEmittedCO2Async(entity);

            var newEntity = await _repository.Add(entity);
            return MapToModel(newEntity);
        }

        public async Task<SolarEnergyModel> Update(SolarEnergyModel model)
        {
            var entity = await _repository.GetById(model.Id);
            if (entity != null)
            {
                // Update properties from model
                entity.UnityID = model.UnityID;
                entity.MonthYear = model.MonthYear;
                entity.Font = model.Font;
                entity.DescriptionFont = model.DescriptionFont;
                entity.AnnualReference = model.AnnualReference;
                entity.QuantityGenerated = model.QuantityGenerated;
                entity.QuantityConsumed = model.QuantityConsumed;

                await CalculateEmittedCO2Async(entity);

                var updatedEntity = await _repository.Update(entity);
                return MapToModel(updatedEntity);
            }
            return null;
        }

        private async Task CalculateEmittedCO2Async(SolarEnergyEntity entity)
        {
            try
            {
                FactorEletricityEntity? factor;
                int year = entity.MonthYear.Year;

                if (entity.AnnualReference)
                {
                    // For annual reference, we look for the specific month and year factor.
                    factor = await _factorRepository.GetFactorAsync(year, entity.MonthYear.Month);
                }
                else
                {
                    // For monthly reference (not annual), we look for the consolidated annual factor (Month = 0).
                    factor = await _factorRepository.GetAnnualFactorAsync(year);
                }

                // Fallback to the latest available annual factor if the specific one is not found.
                // Using 2024 as a hardcoded fallback year as in the original logic.
                factor ??= await _factorRepository.GetAnnualFactorAsync(2024);

                if (factor != null)
                {
                    entity.QuantityEmissaoCO2 = Math.Round(entity.QuantityGenerated * factor.feSIN, 4, MidpointRounding.AwayFromZero);
                }
                else
                {
                    entity.QuantityEmissaoCO2 = 0;
                    _logger.LogWarning("Emission factor not found for year {Year} and entity Id {Id}. CO2 emission set to 0.", year, entity.Id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CalculateEmittedCO2Async for SolarEnergyEntity with Id {Id}", entity.Id);
                // Ensure CO2 is not left with a stale value in case of error
                entity.QuantityEmissaoCO2 = 0;
            }
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        // Manual Mappers
        private SolarEnergyModel MapToModel(SolarEnergyEntity entity)
        {
            if (entity == null) return null;
            return new SolarEnergyModel
            {
                Id = entity.Id,
                UnityID = entity.UnityID,
                MonthYear = entity.MonthYear,
                Font = entity.Font,
                DescriptionFont = entity.DescriptionFont,
                AnnualReference = entity.AnnualReference,
                QuantityGenerated = entity.QuantityGenerated,
                QuantityConsumed = entity.QuantityConsumed,
                UnityName = entity.UnityObject?.Name,
                CO2 = entity.QuantityEmissaoCO2

            };
        }

        private SolarEnergyEntity MapToEntity(SolarEnergyModel model)
        {
            if (model == null) return null;
            return new SolarEnergyEntity
            {
                Id = model.Id,
                UnityID = model.UnityID,
                MonthYear = model.MonthYear,
                Font = model.Font,
                DescriptionFont = model.DescriptionFont,
                AnnualReference = model.AnnualReference,
                QuantityGenerated = model.QuantityGenerated,
                QuantityConsumed = model.QuantityConsumed,
                // Default values are set here and recalculated in the service
                QuantityEmissaoCO2 = 0,
                QuantityEmissionCO2Biogenic = 0,
                QuantityEmissionCO2BiogenicRemoved = 0
            };
        }
    }
}