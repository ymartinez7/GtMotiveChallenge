namespace GtMotive.Estimate.Microservice.Domain.Events
{
    /// <summary>
    /// EventsRegister.
    /// </summary>
    public static class EventsRegister
    {
        /// <summary>
        /// BookingConfirmed.
        /// </summary>
        public static readonly DomainEvent<BookingCreatedDomainEvent> BookingCreated = new();

        /// <summary>
        /// BookingConfirmed.
        /// </summary>
        public static readonly DomainEvent<BookingConfirmedDomainEvent> BookingConfirmed = new();

        /// <summary>
        /// BookingCanceled.
        /// </summary>
        public static readonly DomainEvent<BookingCanceledDomainEvent> BookingCanceled = new();

        /// <summary>
        /// BookingFinished.
        /// </summary>
        public static readonly DomainEvent<BookingFinishedDomainEvent> BookingFinished = new();

        /// <summary>
        /// VehicleAdded.
        /// </summary>
        public static readonly DomainEvent<VehicleAddedDomainEvent> VehicleAdded = new();
    }
}
