using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Cancel;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Common;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Finish;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.GetDetails;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.MakeNew;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Pay;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// BookingsController.
    /// </summary>
    /// <param name="sender">sender.</param>
    /// <param name="logger">logger.</param>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BookingsController(
        ISender sender,
        IAppLogger<BookingsController> logger) : ControllerBase
    {
        private readonly ISender _sender = sender;
        private readonly IAppLogger<BookingsController> _logger = logger;

        /// <summary>
        /// Gets a booking by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>A booking.</returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BookingResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(
            Guid id,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Get booking request received. {BookingId}",
                id);

            var presenter = await _sender.Send(new GetBookingDetailsRequest(id), cancellationToken);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Create a new booking.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>A booking added.</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BookingResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> MakeNew(
            MakeNewBookingRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Entering Post. Request: {@request}",
                request);

            var presenter = await _sender.Send(request, cancellationToken);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Pay a booking.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="request">request.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Message.</returns>
        [HttpPut("{id}/Pay")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Pay(
            Guid id,
            PaymentDetailRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                $"Entering Post. Booking: {id} will be paid",
                request);

            ArgumentNullException.ThrowIfNull(request);
            var presenter = await _sender.Send(new PayBookingRequest { Id = id, PaymentDetails = request }, cancellationToken);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Finish a booking.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="request">request.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Message..</returns>
        [HttpPut("{id}/Finish")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Finish(
            Guid id,
            ObservationRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                $"Entering Post. Booking: {id} will be finished",
                request);

            ArgumentNullException.ThrowIfNull(request);
            var presenter = await _sender.Send(new FinishBookingRequest { Id = id, Observations = request.Observations }, cancellationToken);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Cancel a booking.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="request">request.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Message.</returns>
        [HttpPut("{id}/Cancel")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Cancel(
            Guid id,
            ObservationRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                $"Entering Post. Booking: {id} will be cancelled",
                request);

            ArgumentNullException.ThrowIfNull(request);

            var presenter = await _sender.Send(new CancelBookingRequest { Id = id, Observations = request.Observations }, cancellationToken);
            return presenter.ActionResult;
        }
    }
}
