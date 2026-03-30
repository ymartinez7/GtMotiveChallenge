using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Find;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Find
{
    public class GetVehicleRequestHandler(
        IAppLogger<GetVehicleRequestHandler> logger,
        IGetVehicleUseCase useCase,
        GetVehiclePresenter presenter) : IRequestHandler<GetVehicleRequest, IWebApiPresenter>
    {
        private readonly IAppLogger<GetVehicleRequestHandler> _logger = logger;
        private readonly IGetVehicleUseCase _useCase = useCase;
        private readonly GetVehiclePresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(GetVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            _logger.LogInformation("Executing GetVehicleRequestHandler");

            var input = new GetVehicleInput(request.Id.Value);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
