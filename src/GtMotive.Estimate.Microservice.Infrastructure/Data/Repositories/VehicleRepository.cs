using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Data.Repositories
{
    public class VehicleRepository(AppDbContext dbContext,
        IAppLogger<BaseRepository<Vehicle>> logger)
        : BaseRepository<Vehicle>(dbContext, logger), IVehicleRepository
    {
        public async Task<bool> IsVpnExists(string vsn)
        {
            return await Context.Set<Vehicle>().AnyAsync(v => v.Vpn == new Domain.ValueObjects.Vpn(vsn));
        }
    }
}
