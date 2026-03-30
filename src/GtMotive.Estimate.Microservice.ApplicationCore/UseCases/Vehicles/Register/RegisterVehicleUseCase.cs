using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Common;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Services;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Register
{
    /// <summary>
    /// RegisterVehicleUseCase.
    /// </summary>
    /// <param name="logger">logger.</param>
    /// <param name="outputPort">outputPort.</param>
    /// <param name="vehicleService">vehicleService.</param>
    /// <param name="unitOfWork">unitOfWork.</param>
    public class RegisterVehicleUseCase(
        IAppLogger<RegisterVehicleUseCase> logger,
        IRegisterVehicleOutputPort outputPort,
        IVehicleService vehicleService,
        IUnitOfWork unitOfWork) : IRegisterVehicleUseCase
    {
        private readonly IAppLogger<RegisterVehicleUseCase> _logger = logger;
        private readonly IRegisterVehicleOutputPort _outputPort = outputPort;
        private readonly IVehicleService _vehicleService = vehicleService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>Task.</returns>
        public async Task Execute(RegisterVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);
            _logger.LogInformation("Executing RegisterVehicleUseCase");

            try
            {
                var vehicle = await _vehicleService.RegisterAsync(
                    input.Vsn,
                    input.ModelBrand,
                    input.ModelName,
                    input.ModelYear,
                    input.Price,
                    input.Currency);

                await _unitOfWork.Save();
                BuildOutput(vehicle);
            }
            catch (VpnAlreadyExistsException ex)
            {
                _logger.LogError(
                    ex,
                    "An exception of {exceptinType} has ocurred. Message {message}",
                    typeof(VpnAlreadyExistsException),
                    ex.Message);

                _outputPort.BadRequestHandle($"{ex.Message}.");
            }
            catch (VehileModelYearNotValidException ex)
            {
                _logger.LogError(
                    ex,
                    "An exception of {exceptinType} has ocurred. Message {message}",
                    typeof(VehileModelYearNotValidException),
                    ex.Message);

                _outputPort.BadRequestHandle($"{ex.Message}. The model actual is {input.ModelYear}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has ocurred. Message {message}", ex.Message);
                throw;
            }
        }

        private void BuildOutput(Vehicle vehicle)
        {
            var output = new VehicleOutput(
                vehicle.Id,
                vehicle.Vpn.Value,
                vehicle.Model,
                vehicle.Price);

            _outputPort.StandardHandle(output);
        }
    }
}
