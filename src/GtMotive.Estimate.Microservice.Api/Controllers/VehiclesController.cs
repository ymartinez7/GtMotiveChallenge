using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Common;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Find;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.List;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Register;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// VehiclesController.
    /// </summary>
    /// <param name="sender">sender.</param>
    /// <param name="logger">logger.</param>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public sealed class VehiclesController(
        ISender sender,
        IAppLogger<VehiclesController> logger) : ControllerBase
    {
        private readonly ISender _sender = sender;
        private readonly IAppLogger<VehiclesController> _logger = logger;

        /// <summary>
        /// List vehicles.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>A list of vehicles.</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<VehicleResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> List(
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("List vehicles request received");
            var presenter = await _sender.Send(new ListVehiclesRequest(), cancellationToken);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Gets a vehicle by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>A vehuicle.</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(VehicleResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation(
                "Get vehicle request received. {VehicleId}",
                id);

            var presenter = await _sender.Send(new GetVehicleRequest(id));
            return presenter.ActionResult;
        }

        /// <summary>
        /// Add a new vehicle.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>A vehicle added.</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(VehicleResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register(
            RegisterVehicleRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Register vehicle request received. {@request}", request);
            var presenter = await _sender.Send(request, cancellationToken);
            return presenter.ActionResult;
        }
    }
}
