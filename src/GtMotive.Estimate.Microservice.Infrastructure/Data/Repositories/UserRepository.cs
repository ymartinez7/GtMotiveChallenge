using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.Data.Context;

namespace GtMotive.Estimate.Microservice.Infrastructure.Data.Repositories
{
    public class UserRepository(AppDbContext dbContext,
        IAppLogger<BaseRepository<User>> logger)
        : BaseRepository<User>(dbContext, logger), IUserRepository
    {
    }
}
