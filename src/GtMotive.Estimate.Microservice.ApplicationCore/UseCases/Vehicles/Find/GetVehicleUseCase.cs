using System;
using System.Globalization;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Common;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Services;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Find
{
    /// <summary>
    /// GetVehicleUseCase.
    /// </summary>
    /// <param name="logger">logger.</param>
    /// <param name="outputPort">outputPort.</param>
    /// <param name="vehicleService">vehicleService.</param>
    /// <param name="cacheService">cacheService.</param>
    public class GetVehicleUseCase(
        IAppLogger<GetVehicleUseCase> logger,
        IGetVehicleOutputPort outputPort,
        IVehicleService vehicleService,
        ICache cacheService) : IGetVehicleUseCase
    {
        private readonly IAppLogger<GetVehicleUseCase> _logger = logger;
        private readonly IGetVehicleOutputPort _outputPort = outputPort;
        private readonly IVehicleService _vehicleService = vehicleService;
        private readonly ICache _cacheService = cacheService;
        private readonly string _cacheKeyTemplate = "vehicles:vehicle-{0}";

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);
            _logger.LogInformation("Executing GetVehicleUseCase VehicleId {VehicleId}", input.Id.ToString());

            try
            {
                var cacheKey = string.Format(CultureInfo.InvariantCulture, _cacheKeyTemplate, input.Id);
                var cacheVehicle = await _cacheService.GetAsync<VehicleOutput>(cacheKey);

                if (cacheVehicle is not null)
                {
                    _outputPort.StandardHandle(cacheVehicle);
                    return;
                }

                var vehicle = await _vehicleService.FindAsync(input.Id);

                await BuildOutput(vehicle, cacheKey);
            }
            catch (VehicleNotFoundException ex)
            {
                _logger.LogError(ex, "An error has ocurred. Message {ex.Message}", ex.Message);
                _outputPort.NotFoundHandle(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has ocurred. Message {ex.Message}", ex.Message);
                throw;
            }
        }

        private async Task BuildOutput(Vehicle vehicle, string cacheKey)
        {
            var output = new VehicleOutput(
                vehicle.Id,
                vehicle.Vpn.Value,
                vehicle.Model,
                vehicle.Price);

            await _cacheService.SetAsync(cacheKey, output, TimeSpan.FromMinutes(2));
            _outputPort.StandardHandle(output);
        }
    }
}
