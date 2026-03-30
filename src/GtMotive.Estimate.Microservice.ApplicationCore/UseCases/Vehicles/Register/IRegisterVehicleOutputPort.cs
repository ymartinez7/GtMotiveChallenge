using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Common;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Register
{
    /// <summary>
    /// IRegisterVehicleOutputPort.
    /// </summary>
    public interface IRegisterVehicleOutputPort : IOutputPortStandard<VehicleOutput>, IOutputPortNotFound, IOutputPortBadRequest
    {
    }
}
