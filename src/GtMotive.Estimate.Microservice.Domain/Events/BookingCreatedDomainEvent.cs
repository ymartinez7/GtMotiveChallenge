using System;

namespace GtMotive.Estimate.Microservice.Domain.Events
{
    /// <summary>
    /// BookingCreatedDomainEvent.
    /// </summary>
    /// <param name="BookingId">BookingId.</param>
    public sealed record BookingCreatedDomainEvent(Guid BookingId);
}
