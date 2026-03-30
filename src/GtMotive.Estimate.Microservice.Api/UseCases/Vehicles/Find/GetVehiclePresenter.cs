using System;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Common;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Common;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Find;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Find
{
    public sealed class GetVehiclePresenter : IWebApiPresenter, IGetVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void StandardHandle(VehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = new VehicleResponse(
                output.Id,
                output.Vpn,
                output.ModelName,
                output.ModelYear,
                output.Price,
                output.Currency);

            ActionResult = new OkObjectResult(response);
        }
    }
}
