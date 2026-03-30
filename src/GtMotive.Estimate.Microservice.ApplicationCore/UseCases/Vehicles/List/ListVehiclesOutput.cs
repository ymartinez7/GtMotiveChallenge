using System;
using System.Collections.Generic;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Common;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.List
{
    /// <summary>
    /// ListVehiclesOutput.
    /// </summary>
    public class ListVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">vehicles.</param>
        public ListVehiclesOutput(IEnumerable<Vehicle> vehicles)
        {
            ArgumentNullException.ThrowIfNull(vehicles);

            Vehicles = Map(vehicles);
        }

        /// <summary>
        /// Gets Vehicles.
        /// </summary>
        public IEnumerable<VehicleOutput> Vehicles { get; private set; }

        /// <summary>
        /// Map.
        /// </summary>
        /// <param name="vehicles">vehicles.</param>
        /// <returns>List of VehicleOutput.</returns>
        private static List<VehicleOutput> Map(IEnumerable<Vehicle> vehicles)
        {
            var vehiclesOutput = new List<VehicleOutput>();

            foreach (var vehicle in vehicles)
            {
                vehiclesOutput.Add(new VehicleOutput(
                vehicle.Id,
                vehicle.Vpn.Value,
                vehicle.Model,
                vehicle.Price));
            }

            return vehiclesOutput;
        }
    }
}
