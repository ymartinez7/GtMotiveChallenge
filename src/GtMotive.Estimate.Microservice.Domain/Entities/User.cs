using System;
using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// User entity.
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        private User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <param name="firstName">Name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="email">Email.</param>
        private User(
            Guid id,
            FirstName firstName,
            LastName lastName,
            Email email)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        /// <summary>
        /// Gets user first name.
        /// </summary>
        public FirstName FirstName { get; private set; }

        /// <summary>
        /// Gets user last name.
        /// </summary>
        public LastName LastName { get; private set; }

        /// <summary>
        /// Gets user email.
        /// </summary>
        public Email Email { get; private set; }

        /// <summary>
        /// Gets users bookings.
        /// </summary>
        public virtual ICollection<Booking> Bookings { get; private set; } = [];

        /// <summary>
        /// Create an instance of user.
        /// </summary>
        /// <param name="firtsName">firtsName.</param>
        /// <param name="lastName">lastName.</param>
        /// <param name="email">email.</param>
        /// <returns>A User instance.</returns>
        public static User Create(
            FirstName firtsName,
            LastName lastName,
            Email email)
        {
            var user = new User(
                Guid.NewGuid(),
                firtsName,
                lastName,
                email);

            return user;
        }
    }
}
