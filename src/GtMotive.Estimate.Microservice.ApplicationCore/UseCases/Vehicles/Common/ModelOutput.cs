namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Common
{
    /// <summary>
    /// ModelOutput.
    /// </summary>
    /// <param name="Name">Name.</param>
    /// <param name="Year">Year.</param>
    public record ModelOutput(
        string Name,
        int Year)
    {
    }
}
