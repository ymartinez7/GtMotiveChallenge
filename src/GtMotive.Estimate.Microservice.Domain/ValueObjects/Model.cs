namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Model value object.
    /// </summary>
    /// <param name="Brand">Brand.</param>
    /// <param name="Name">Name.</param>
    /// <param name="Year">Year.</param>
    public sealed record Model(
        string Brand,
        string Name,
        int Year);
}
