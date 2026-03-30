using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Common
{
    /// <summary>
    /// VehicleResponse.
    /// </summary>
    /// <param name="id">id.</param>
    /// <param name="vpn">vsn.</param>
    /// <param name="modelName">modelName.</param>
    /// <param name="modelYear">modelYear.</param>
    /// <param name="price">price.</param>
    /// <param name="currency">currency.</param>
    public class VehicleResponse(
        Guid id,
        string vpn,
        string modelName,
        int modelYear,
        decimal price,
        string currency)
    {
        /// <summary>
        /// Gets Id.
        /// </summary>
        public Guid Id { get; private set; } = id;

        /// <summary>
        /// Gets Vsn.
        /// </summary>
        public string Vpn { get; } = vpn;

        /// <summary>
        /// Gets ModelName.
        /// </summary>
        public string ModelName { get; private set; } = modelName;

        /// <summary>
        /// Gets aa.
        /// </summary>
        public int ModelYear { get; private set; } = modelYear;

        /// <summary>
        /// Gets price.
        /// </summary>
        public decimal Price { get; private set; } = price;

        /// <summary>
        /// Gets Currency.
        /// </summary>
        public string Currency { get; private set; } = currency;
    }
}
