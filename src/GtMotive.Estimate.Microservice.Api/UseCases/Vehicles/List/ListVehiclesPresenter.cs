using System;
using System.Collections.Generic;
using System.Linq;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Common;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.List;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.List
{
    public sealed class ListVehiclesPresenter : IWebApiPresenter, IListVehiclesOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ListVehiclesOutput list)
        {
            ArgumentNullException.ThrowIfNull(list);

            if (!list.Vehicles.Any())
            {
                ActionResult = new NoContentResult();
                return;
            }

            var vehicleList = new List<VehicleResponse>();

            foreach (var vehicle in list.Vehicles)
            {
                vehicleList.Add(new VehicleResponse(
                vehicle.Id,
                vehicle.Vpn,
                vehicle.ModelName,
                vehicle.ModelYear,
                vehicle.Price,
                vehicle.Currency));
            }

            ActionResult = new OkObjectResult(vehicleList);
        }

        public void NotFoundHandle(string message)
        {
            throw new NotImplementedException();
        }
    }
}
