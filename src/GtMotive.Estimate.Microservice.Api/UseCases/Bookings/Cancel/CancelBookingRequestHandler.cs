using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Cancel;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Cancel
{
    public class CancelBookingRequestHandler(
        IAppLogger<CancelBookingRequestHandler> logger,
        ICancelBookingUseCase useCase,
        CancelBookingPresenter presenter) : IRequestHandler<CancelBookingRequest, IWebApiPresenter>
    {
        private readonly IAppLogger<CancelBookingRequestHandler> _logger = logger;
        private readonly ICancelBookingUseCase _useCase = useCase;
        private readonly CancelBookingPresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(CancelBookingRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            _logger.LogInformation("Exeuting CancelBookingRequestHandler");

            var input = new CancelBookingInput(
                request.Id.Value,
                request.Observations);

            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
