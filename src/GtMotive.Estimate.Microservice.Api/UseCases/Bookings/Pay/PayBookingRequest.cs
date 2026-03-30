using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Pay
{
    public class PayBookingRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets PaymentDetails.
        /// </summary>
        public PaymentDetailRequest PaymentDetails { get; set; }
    }
}
