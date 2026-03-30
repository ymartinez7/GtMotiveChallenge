using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    internal static class VehicleData
    {
        public static Vehicle Create(Money price) =>
            Vehicle.Create(
        new Model(
            "Nissan",
            "Qashqai",
            2023),
        new Vpn("AAA-123"),
        price);
    }
}
