using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Find
{
    public class GetVehicleRequest(Guid id) : IRequest<IWebApiPresenter>
    {
        public Guid? Id { get; private set; } = id;
    }
}
