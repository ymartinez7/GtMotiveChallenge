using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Finish;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Finish
{
    public class FinishBookingRequestHandler(
        IAppLogger<FinishBookingRequestHandler> logger,
        IFinishBookingUseCase useCase,
        FinishBookingPresenter presenter) : IRequestHandler<FinishBookingRequest, IWebApiPresenter>
    {
        private readonly IAppLogger<FinishBookingRequestHandler> _logger = logger;
        private readonly IFinishBookingUseCase _useCase = useCase;
        private readonly FinishBookingPresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(FinishBookingRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            _logger.LogInformation("Executing FinishBookingRequestHandler");

            var input = new FinishBookingInput(
                request.Id.Value,
                request.Observations);

            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
