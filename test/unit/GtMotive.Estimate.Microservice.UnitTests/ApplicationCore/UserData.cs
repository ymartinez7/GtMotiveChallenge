using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    internal static class UserData
    {
        public static readonly FirstName FirstName = new("TestFirstName");
        public static readonly LastName LastName = new("TestlASTName");
        public static readonly Email Email = new("TestUser@test.com");
    }
}
