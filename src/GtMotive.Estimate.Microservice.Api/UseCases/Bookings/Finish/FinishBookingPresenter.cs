using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Finish;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Finish
{
    public class FinishBookingPresenter : IWebApiPresenter, IFinishBookingOutputPort
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

        public void StandardHandle(FinishBookingOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            ActionResult = new OkObjectResult(output.Message);
        }
    }
}
