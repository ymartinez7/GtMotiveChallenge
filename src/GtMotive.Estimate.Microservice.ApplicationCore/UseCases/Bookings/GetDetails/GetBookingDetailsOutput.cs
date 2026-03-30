using System;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.GetDetails
{
    /// <summary>
    /// GetBookingDetailsOutput.
    /// </summary>
    public class GetBookingDetailsOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetBookingDetailsOutput"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="vehicleId">vehicleId.</param>
        /// <param name="userId">userId.</param>
        /// <param name="startDate">startDate.</param>
        /// <param name="endDate">endDate.</param>
        /// <param name="totalPrice">totalPrice.</param>
        /// <param name="status">status.</param>
        public GetBookingDetailsOutput(
            Guid id,
            Guid vehicleId,
            Guid userId,
            DateOnly startDate,
            DateOnly endDate,
            decimal totalPrice,
            BookingStatus status)
        {
            Id = id;
            UserId = userId;
            VehicleId = vehicleId;
            StartDate = startDate;
            EndDate = endDate;
            TotalPrice = totalPrice;
            Status = status.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetBookingDetailsOutput"/> class.
        /// </summary>
        public GetBookingDetailsOutput()
        {
        }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets vehicleId.
        /// </summary>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets userId.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets startDate.
        /// </summary>
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// Gets or sets endDate.
        /// </summary>
        public DateOnly EndDate { get; set; }

        /// <summary>
        /// Gets or sets totalPrice.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets status.
        /// </summary>
        public string Status { get; set; }
    }
}
