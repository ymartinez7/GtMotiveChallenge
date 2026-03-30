using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Events;

namespace GtMotive.Estimate.Microservice.ApplicationCore.EventHandlers
{
    /// <summary>
    /// BookingCreatedEventHandler.
    /// </summary>
    public class BookingCreatedEventHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingCreatedEventHandler"/> class.
        /// </summary>
        public BookingCreatedEventHandler()
        {
            EventsRegister.BookingCreated.Register(async parameter =>
            {
                // Handlimng of the event to execute additional process or for publish any integration event
                await Task.CompletedTask;
            });
        }
    }
}
