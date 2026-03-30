using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.List;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.List
{
    public class ListVehiclesRequestHandler(
        IAppLogger<ListVehiclesRequestHandler> logger,
        IListVehiclesUseCase useCase,
        ListVehiclesPresenter presenter) : IRequestHandler<ListVehiclesRequest, IWebApiPresenter>
    {
        private readonly IAppLogger<ListVehiclesRequestHandler> _logger = logger;
        private readonly IListVehiclesUseCase _useCase = useCase;
        private readonly ListVehiclesPresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(
            ListVehiclesRequest request,
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            _logger.LogInformation($"Executing ListVehiclesRequestHandler");

            var input = new ListVehiclesInput();
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
