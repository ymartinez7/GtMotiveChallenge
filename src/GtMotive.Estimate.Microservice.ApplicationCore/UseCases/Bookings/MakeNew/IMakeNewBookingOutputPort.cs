namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.MakeNew
{
    /// <summary>
    /// IMakeNewBookingOutputPort.
    /// </summary>
    public interface IMakeNewBookingOutputPort : IOutputPortStandard<MakeNewBookingOutput>, IOutputPortNotFound, IOutputPortBadRequest
    {
    }
}
