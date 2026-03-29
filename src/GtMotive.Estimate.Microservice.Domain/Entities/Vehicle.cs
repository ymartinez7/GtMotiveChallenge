using System;
using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// VehicLe entity.
    /// </summary>
    public class Vehicle : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        private Vehicle()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="model">Model.</param>
        /// <param name="vpn">VSN.</param>
        /// <param name="price">pRICE.</param>
        private Vehicle(
            Guid id,
            Model model,
            Vpn vpn,
            Money price)
            : base(id)
        {
            Id = id;
            Model = model;
            Vpn = vpn;
            Price = price;
        }

        /// <summary>
        /// Gets vehicle model.
        /// </summary>
        public Model Model { get; private set; }

        /// <summary>
        /// Gets vehicle plate number.
        /// </summary>
        public Vpn Vpn { get; private set; }

        /// <summary>
        /// Gets price.
        /// </summary>
        public Money Price { get; private set; }

        /// <summary>
        /// Gets last booked.
        /// </summary>
        public DateTime LastBookedOnUtc { get; internal set; }

        /// <summary>
        /// Gets bookings.
        /// </summary>
        public virtual ICollection<Booking> Bookings { get; private set; } = [];

        /// <summary>
        /// Create an instance of vehicle.
        /// </summary>
        /// <param name="model">model.</param>
        /// <param name="vpn">vsn.</param>
        /// <param name="price">price.</param>
        /// <returns>An instance of vehicle.</returns>
        public static Vehicle Create(
            Model model,
            Vpn vpn,
            Money price)
        {
            var vehicle = new Vehicle(
                Guid.NewGuid(),
                model,
                vpn,
                price);

            return vehicle;
        }
    }
}
