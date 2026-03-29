using System;

namespace GtMotive.Estimate.Microservice.Domain.Events
{
    /// <summary>
    /// BookingFinishedDomainEvent.
    /// </summary>
    /// <param name="BookingId">BookingId.</param>
    public sealed record BookingFinishedDomainEvent(Guid BookingId);
}
