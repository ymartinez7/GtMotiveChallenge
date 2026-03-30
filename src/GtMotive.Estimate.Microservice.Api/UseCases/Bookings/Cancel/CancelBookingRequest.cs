using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Cancel
{
    public class CancelBookingRequest : IRequest<IWebApiPresenter>
    {
        public Guid? Id { get; set; }

        public string Observations { get; set; }
    }
}
