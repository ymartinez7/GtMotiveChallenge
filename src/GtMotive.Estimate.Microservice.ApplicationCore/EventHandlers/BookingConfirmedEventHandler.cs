using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Events;

namespace GtMotive.Estimate.Microservice.ApplicationCore.EventHandlers
{
    /// <summary>
    /// BookingConfirmedEventHandler.
    /// </summary>
    public class BookingConfirmedEventHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingConfirmedEventHandler"/> class.
        /// </summary>
        public BookingConfirmedEventHandler()
        {
            EventsRegister.BookingConfirmed.Register(async parameter =>
            {
                // Handlimng of the event to execute additional process or for publish any integration event
                await Task.CompletedTask;
            });
        }
    }
}
