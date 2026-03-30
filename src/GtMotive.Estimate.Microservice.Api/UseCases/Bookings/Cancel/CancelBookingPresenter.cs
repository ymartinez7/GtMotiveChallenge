using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Cancel;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Cancel
{
    public class CancelBookingPresenter : IWebApiPresenter, ICancelBookingOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void BadRequestHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void StandardHandle(CancelBookingOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            ActionResult = new OkObjectResult(output.Message);
        }
    }
}
