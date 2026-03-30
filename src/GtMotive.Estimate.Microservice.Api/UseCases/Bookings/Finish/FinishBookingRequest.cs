using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Finish
{
    /// <summary>
    /// FinishBookingRequest.
    /// </summary>
    public class FinishBookingRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets Observations.
        /// </summary>
        public string Observations { get; set; }
    }
}
