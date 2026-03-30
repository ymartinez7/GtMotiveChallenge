namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// IOutputPortBadRequest.
    /// </summary>
    public interface IOutputPortBadRequest
    {
        /// <summary>
        /// BadRequestHandle.
        /// </summary>
        /// <param name="message">message.</param>
        void BadRequestHandle(string message);
    }
}
