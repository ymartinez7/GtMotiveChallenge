using System;

namespace GtMotive.Estimate.Microservice.Domain.Events
{
    /// <summary>
    /// BookingCanceledDomainEvent.
    /// </summary>
    /// <param name="BookingId">BookingId.</param>
    public sealed record BookingCanceledDomainEvent(Guid BookingId);
}
