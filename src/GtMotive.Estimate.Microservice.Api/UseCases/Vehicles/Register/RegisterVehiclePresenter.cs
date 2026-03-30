using System;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Common;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Common;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Register;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Register
{
    public sealed class RegisterVehiclePresenter : IWebApiPresenter, IRegisterVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

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
            throw new NotImplementedException();
        }

        public void BadRequestHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }
    }
}
