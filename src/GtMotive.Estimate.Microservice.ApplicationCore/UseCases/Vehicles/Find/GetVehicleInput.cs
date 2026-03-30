using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Find
{
    /// <summary>
    /// GetVehicleInput.
    /// </summary>
    public class GetVehicleInput(Guid id) : IUseCaseInput
    {
        /// <summary>
        /// Gets Id.
        /// </summary>
        public Guid Id { get; private set; } = id;
    }
}
