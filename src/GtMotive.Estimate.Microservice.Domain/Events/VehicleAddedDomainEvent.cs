using System;

namespace GtMotive.Estimate.Microservice.Domain.Events
{
    /// <summary>
    /// VehicleAddedDomainEvent.
    /// </summary>
    /// <param name="VehicleId">VehicleId.</param>
    public record VehicleAddedDomainEvent(Guid VehicleId);
}
