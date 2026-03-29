using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Base repository class.
    /// </summary>
    /// <typeparam name="T">class.</typeparam>
    public interface IBaseRepository<T>
        where T : Entity
    {
        /// <summary>
        /// Gets all data.
        /// </summary>
        /// <returns>List.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets data base on id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Returns item.</returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Add new item.
        /// </summary>
        /// <param name="entity">Entoty.</param>
        /// <returns>Returns item added.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Update an item.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Update(T entity);

        /// <summary>
        /// Delete an item.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Delete(T entity);
    }
}
