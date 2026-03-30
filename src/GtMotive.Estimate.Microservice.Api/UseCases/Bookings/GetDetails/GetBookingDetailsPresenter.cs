using System;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Common;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.GetDetails;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.GetDetails
{
    public class GetBookingDetailsPresenter : IWebApiPresenter, IGetBookingDetailsOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void StandardHandle(GetBookingDetailsOutput output)
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

            ActionResult = new OkObjectResult(response);
        }
    }
}
