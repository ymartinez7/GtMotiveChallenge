namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Cancel
{
    /// <summary>
    /// ICancelBookingOutputPort.
    /// </summary>
    public interface ICancelBookingOutputPort : IOutputPortStandard<CancelBookingOutput>, IOutputPortNotFound, IOutputPortBadRequest
    {
    }
}
