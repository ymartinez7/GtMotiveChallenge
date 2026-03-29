using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Base entity.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        protected Entity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="id">RR.</param>
        protected Entity(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets Id.
        /// </summary>
        public Guid Id { get; init; }
    }
}
