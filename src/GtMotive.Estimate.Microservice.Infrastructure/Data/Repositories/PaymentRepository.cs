using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.Data.Context;

namespace GtMotive.Estimate.Microservice.Infrastructure.Data.Repositories
{
    public class PaymentRepository(
        AppDbContext ccntext,
        IAppLogger<BaseRepository<Payment>> logger)
        : BaseRepository<Payment>(ccntext, logger), IPaymentRepository
    {
    }
}
