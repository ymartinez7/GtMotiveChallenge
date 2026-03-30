namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Register
{
    /// <summary>
    /// RegisterVehicleInput.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="RegisterVehicleInput"/> class.
    /// </remarks>
    /// <param name="vsn">vsn.</param>
    /// <param name="modelBrand">modelBrand.</param>
    /// <param name="modelName">modelName.</param>
    /// <param name="modelYear">modelYear.</param>
    /// <param name="price">price.</param>
    /// <param name="currency">currency.</param>
    public class RegisterVehicleInput(string vsn,
        string modelBrand,
        string modelName,
        int modelYear,
        decimal price,
        string currency) : IUseCaseInput
    {
        /// <summary>
        /// Gets Vsn.
        /// </summary>
        public string Vsn { get; private set; } = vsn;

        /// <summary>
        /// Gets ModelBrand.
        /// </summary>
        public string ModelBrand { get; private set; } = modelBrand;

        /// <summary>
        /// Gets ModelName.
        /// </summary>
        public string ModelName { get; private set; } = modelName;

        /// <summary>
        /// Gets or sets ModelYear.
        /// </summary>
        public int ModelYear { get; set; } = modelYear;

        /// <summary>
        /// Gets Price.
        /// </summary>
        public decimal Price { get; private set; } = price;

        /// <summary>
        /// Gets or sets Currency.
        /// </summary>
        public string Currency { get; set; } = currency;
    }
}
