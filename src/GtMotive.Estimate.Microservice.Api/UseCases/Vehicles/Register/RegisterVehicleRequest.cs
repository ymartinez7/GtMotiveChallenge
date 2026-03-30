using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Register
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterVehicleRequest"/> class.
    /// </summary>
    /// <param name="vps">vps.</param>
    /// <param name="modelBrand">modelBrand..</param>
    /// <param name="modelName">modelName.</param>
    /// <param name="modelYear">modelYear.</param>
    /// <param name="price">price.</param>
    /// <param name="currency">currency.</param>
    public class RegisterVehicleRequest(
        string vps,
        string modelBrand,
        string modelName,
        int modelYear,
        decimal price,
        string currency) : IRequest<IWebApiPresenter>
    {
        public string Vps { get; private set; } = vps;

        public string ModelBrand { get; private set; } = modelBrand;

        public string ModelName { get; private set; } = modelName;

        public int ModelYear { get; set; } = modelYear;

        public decimal Price { get; private set; } = price;

        public string Currency { get; set; } = currency;
    }
}
