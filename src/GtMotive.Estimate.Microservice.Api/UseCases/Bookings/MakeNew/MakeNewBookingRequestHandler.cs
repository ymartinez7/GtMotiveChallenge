using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.MakeNew;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.MakeNew
{
    public class MakeNewBookingRequestHandler(
        IAppLogger<MakeNewBookingRequestHandler> logger,
        IMakeNewBookingUseCase useCase,
        MakeNewBookingPresenter presenter) : IRequestHandler<MakeNewBookingRequest, IWebApiPresenter>
    {
        private readonly IAppLogger<MakeNewBookingRequestHandler> _logger = logger;
        private readonly IMakeNewBookingUseCase _useCase = useCase;
        private readonly MakeNewBookingPresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(MakeNewBookingRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            _logger.LogInformation("Executing MakeNewBookingRequestHandler");

            var input = new MakeNewBookingInput(
                request.UserId,
                request.VehicleId,
                request.StartDate,
                request.EndDate);

            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
