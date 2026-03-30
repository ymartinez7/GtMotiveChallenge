using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Services;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.List
{
    /// <summary>
    /// ListVehiclesUseCase.
    /// </summary>
    /// <param name="logger">logger.</param>
    /// <param name="outputPort">outputPort.</param>
    /// <param name="vehicleService">vehicleService.</param>
    public class ListVehiclesUseCase(
        IAppLogger<ListVehiclesUseCase> logger,
        IListVehiclesOutputPort outputPort,
        IVehicleService vehicleService) : IListVehiclesUseCase
    {
        private readonly IAppLogger<ListVehiclesUseCase> _logger = logger;
        private readonly IListVehiclesOutputPort _outputPort = outputPort;
        private readonly IVehicleService _vehicleService = vehicleService;

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>Task.</returns>
        public async Task Execute(ListVehiclesInput input)
        {
            try
            {
                _logger.LogInformation($"Executing ListVehiclesUseCase");
                var vehicles = await _vehicleService.ListAsync();
                BuildOutput(vehicles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has ocurred. Message: {ex.Message}");
                throw;
            }
        }

        private void BuildOutput(IEnumerable<Vehicle> vehicles)
        {
            var output = new ListVehiclesOutput(vehicles);
            _outputPort.StandardHandle(output);
        }
    }
}
