using System;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Common;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.MakeNew;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.MakeNew
{
    public class MakeNewBookingPresenter : IWebApiPresenter, IMakeNewBookingOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(MakeNewBookingOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = new BookingResponse(
                output.Id,
                output.VehicleId,
                output.UserId,
                output.StartDate,
                output.EndDate,
                output.TotalPrice,
                output.Status);

            ActionResult = new CreatedAtActionResult(
                "Get",
                null,
                new
                {
                    id = response.Id
                },
                response);
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void BadRequestHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }
    }
}
