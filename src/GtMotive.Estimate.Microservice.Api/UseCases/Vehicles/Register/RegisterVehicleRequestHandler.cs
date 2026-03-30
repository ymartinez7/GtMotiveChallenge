using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Register;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Register
{
    public class RegisterVehicleRequestHandler(
        IAppLogger<RegisterVehicleRequestHandler> logger,
        IRegisterVehicleUseCase useCase,
        RegisterVehiclePresenter presenter) : IRequestHandler<RegisterVehicleRequest, IWebApiPresenter>
    {
        private readonly IAppLogger<RegisterVehicleRequestHandler> _logger = logger;
        private readonly IRegisterVehicleUseCase _useCase = useCase;
        private readonly RegisterVehiclePresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(
            RegisterVehicleRequest request,
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            _logger.LogInformation("Executing RegisterVehicleRequestHandler");

            var input = new RegisterVehicleInput(
                request.Vpn,
                request.ModelBrand,
                request.ModelName,
                request.ModelYear,
                request.Price,
                request.Currency);

            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
