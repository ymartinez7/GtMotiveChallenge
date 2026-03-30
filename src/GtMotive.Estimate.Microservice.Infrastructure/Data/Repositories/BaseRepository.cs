using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Data.Repositories
{
    public class BaseRepository<T>(AppDbContext ccntext,
        IAppLogger<BaseRepository<T>> logger) : IBaseRepository<T>
        where T : Entity
    {
        private readonly IAppLogger<BaseRepository<T>> _logger = logger;

        protected AppDbContext Context { get; init; } = ccntext;

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            _logger.LogInformation($"GetAllAsync");
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            _logger.LogInformation($"GetByIdAsync");
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            _logger.LogInformation($"AddAsync");
            await Context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            _logger.LogInformation($"Update");
            Context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogInformation($"DeleteAsync");
            var entity = await GetByIdAsync(id);
            ArgumentException.ThrowIfNullOrEmpty(nameof(entity));
            Delete(entity);
        }

        public void Delete(T entity)
        {
            _logger.LogInformation($"Delete");
            Context.Set<T>().Remove(entity);
        }
    }
}
