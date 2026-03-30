using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.GetDetails;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.GetDetails
{
    public class GetBookingDetailsRequestHandler(
        IAppLogger<GetBookingDetailsRequestHandler> logger,
        IGetBookingDetailsUseCase useCase,
        GetBookingDetailsPresenter presenter) : IRequestHandler<GetBookingDetailsRequest, IWebApiPresenter>
    {
        private readonly IAppLogger<GetBookingDetailsRequestHandler> _logger = logger;
        private readonly IGetBookingDetailsUseCase _useCase = useCase;
        private readonly GetBookingDetailsPresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(
            GetBookingDetailsRequest request,
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            _logger.LogInformation("Executing GetBookingDetailsRequestHandler");

            var input = new GetBookingDetailsInput(request.Id.Value);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
