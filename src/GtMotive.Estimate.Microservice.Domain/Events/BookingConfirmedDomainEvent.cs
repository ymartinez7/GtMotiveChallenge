using System;

namespace GtMotive.Estimate.Microservice.Domain.Events
{
    /// <summary>
    /// BookingConfirmedDomainEvent.
    /// </summary>
    /// <param name="BookingId">BookingId.</param>
    public sealed record BookingConfirmedDomainEvent(Guid BookingId);
}
