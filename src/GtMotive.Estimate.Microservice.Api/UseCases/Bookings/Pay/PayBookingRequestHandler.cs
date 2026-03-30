using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Pay;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Pay
{
    public class PayBookingRequestHandler(
        IAppLogger<PayBookingRequestHandler> logger,
        IPayBookingUseCase useCase,
        PayBookingPreseter presenter) : IRequestHandler<PayBookingRequest, IWebApiPresenter>
    {
        private readonly IAppLogger<PayBookingRequestHandler> _logger = logger;
        private readonly IPayBookingUseCase _useCase = useCase;
        private readonly PayBookingPreseter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(PayBookingRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            _logger.LogInformation("Executing PayBookingRequestHandler");

            var input = new PayBookingInput(
                request.Id.Value,
                new PaymentDetailInput(
                    request.PaymentDetails.Paymentype,
                    request.PaymentDetails.CardNumber.Value,
                    request.PaymentDetails.ExpirationDate.Value));

            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
