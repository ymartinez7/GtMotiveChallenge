using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Common;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Find
{
    /// <summary>
    /// IGetVehicleOutputPort.
    /// </summary>
    public interface IGetVehicleOutputPort : IOutputPortStandard<VehicleOutput>, IOutputPortNotFound
    {
    }
}
