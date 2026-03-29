using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Services
{
    /// <summary>
    /// Vehicle Service interface.
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// FindAsync.
        /// </summary>
        /// <param name="vehicleId">vehicleId.</param>
        /// <returns>Vehicle.</returns>
        Task<Vehicle> FindAsync(Guid vehicleId);

        /// <summary>
        /// ListAsync.
        /// </summary>
        /// <returns>Vehicle.</returns>
        Task<IEnumerable<Vehicle>> ListAsync();

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
        Task<Vehicle> RegisterAsync(
            string vpn,
            string modelBrand,
            string modelName,
            int modelYear,
            decimal price,
            string currency);
    }
}
