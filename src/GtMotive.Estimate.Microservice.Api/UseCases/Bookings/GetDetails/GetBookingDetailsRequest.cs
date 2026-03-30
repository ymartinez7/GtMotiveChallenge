using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.GetDetails
{
    public class GetBookingDetailsRequest(Guid id) : IRequest<IWebApiPresenter>
    {
        public Guid? Id { get; private set; } = id;
    }
}
