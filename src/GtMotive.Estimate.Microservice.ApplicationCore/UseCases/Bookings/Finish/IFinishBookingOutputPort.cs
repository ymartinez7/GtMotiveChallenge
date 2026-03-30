namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Finish
{
    /// <summary>
    /// IFinishBookingOutputPort.
    /// </summary>
    public interface IFinishBookingOutputPort : IOutputPortStandard<FinishBookingOutput>, IOutputPortNotFound, IOutputPortBadRequest
    {
    }
}
