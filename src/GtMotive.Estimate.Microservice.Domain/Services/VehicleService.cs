using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Events;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Services;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Services
{
    /// <summary>
    /// Vehicle service.
    /// </summary>
    public class VehicleService(
        IAppLogger<VehicleService> logger,
        IVehicleRepository vehicleRepository) : IVehicleService
    {
        private readonly IAppLogger<VehicleService> _logger = logger;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        /// <summary>
        /// FindAsync.
        /// </summary>
        /// <param name="vehicleId">vehicleId.</param>
        /// <returns>Vehicle.</returns>
        /// <exception cref="NotImplementedException">NotImplementedException.</exception>
        public async Task<Vehicle> FindAsync(Guid vehicleId)
        {
            _logger.LogInformation("Getting vehicle {VehicleId}", vehicleId);

            var vehicle = await _vehicleRepository.GetByIdAsync(vehicleId);

            return vehicle is null ? throw new VehicleNotFoundException("Vehicle not found") : vehicle;
        }

        /// <summary>
        /// ListAsync.
        /// </summary>
        /// <returns>List of vehicle.</returns>
        /// <exception cref="NotImplementedException">NotImplementedException.</exception>
        public async Task<IEnumerable<Vehicle>> ListAsync()
        {
            _logger.LogInformation("Gettings all vehicles");
            return await _vehicleRepository.GetAllAsync();
        }

        /// <summary>
        /// RegisterAsync.
        /// </summary>
        /// <param name="vpn">vsn.</param>
        /// <param name="modelBrand">modelBrand.</param>
        /// <param name="modelName">modelName.</param>
        /// <param name="modelYear">modelYear.</param>
        /// <param name="price">price.</param>
        /// <param name="currency">currency.</param>
        /// <returns>Vehicle.</returns>
        /// <exception cref="VpnAlreadyExistsException">VsnAlreadyExistsException.</exception>
        /// <exception cref="VehileModelYearNotValidException">VehileModelYearNotValidException.</exception>
        public async Task<Vehicle> RegisterAsync(
            string vpn,
            string modelBrand,
            string modelName,
            int modelYear,
            decimal price,
            string currency)
        {
            _logger.LogInformation("Registering new vehicle");

            var isVsnExists = await _vehicleRepository.IsVpnExists(vpn);

            if (isVsnExists)
            {
                throw new VpnAlreadyExistsException($"The VSN: {vpn} already exists. It can not be registered twice");
            }

            var isModelValid = ValidateModelYear(modelYear);

            if (!isModelValid)
            {
                throw new VehileModelYearNotValidException($"The model year of vehicle is invalid. Only it's permited until 5 years");
            }

            var vehicle = Vehicle.Create(
                    new Model(modelBrand, modelName, modelYear),
                    new Vpn(vpn),
                    new Money(price, Currency.FromCode(currency)));

            var newVehicle = await _vehicleRepository.AddAsync(vehicle);

            // Raise a domain event when a new vehicle is added
            EventsRegister.VehicleAdded.Publish(new VehicleAddedDomainEvent(vehicle.Id));

            return newVehicle;
        }

        private static bool ValidateModelYear(int year)
        {
            var date = new DateOnly(year, 1, 1);
            var currentDate = DateTime.UtcNow;
            var totalYears = Math.Abs(date.Year - currentDate.Year);
            return totalYears <= 5;
        }
    }
}
