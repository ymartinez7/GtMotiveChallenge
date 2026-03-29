using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Vehicle repository interface.
    /// </summary>
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        /// <summary>
        /// Evaluate if there is a vehicle with same plate number.
        /// </summary>
        /// <param name="vsn">vsn.</param>
        /// <returns>boolean.</returns>
        Task<bool> IsVpnExists(string vsn);
    }
}
