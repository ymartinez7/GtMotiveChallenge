namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// PricingDetail value object.
    /// </summary>
    /// <param name="PriceByPeriod">PriceByPeriod.</param>
    /// <param name="TotalPrice">TotalPrice.</param>
    public sealed record PricingDetail(
        Money PriceByPeriod,
        Money TotalPrice);
}
