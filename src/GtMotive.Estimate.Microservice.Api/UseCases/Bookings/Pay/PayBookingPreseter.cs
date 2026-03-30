using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Pay;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Pay
{
    public class PayBookingPreseter : IWebApiPresenter, IPayBookingOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void StandardHandle(PayBookingOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            ActionResult = new OkObjectResult(output.Message);
        }
    }
}
