using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Common
{
    /// <summary>
    /// VehicleOutput.
    /// </summary>
    public class VehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleOutput"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="vpn">vsn.</param>
        /// <param name="model">model.</param>
        /// <param name="price">price.</param>
        public VehicleOutput(
            Guid id,
            string vpn,
            Model model,
            Money price)
        {
            ArgumentNullException.ThrowIfNull(model);
            ArgumentNullException.ThrowIfNull(price);

            Id = id;
            Vpn = vpn;
            ModelName = model.Name;
            ModelYear = model.Year;
            Price = price.Amount;
            Currency = price.Currency.Code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleOutput"/> class.
        /// </summary>
        public VehicleOutput()
        {
        }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets vsn.
        /// </summary>
        public string Vpn { get; set; }

        /// <summary>
        /// Gets or sets modelName.
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Gets or sets modelYear.
        /// </summary>
        public int ModelYear { get; set; }

        /// <summary>
        /// Gets or sets price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public string Currency { get; set; }
    }
}
