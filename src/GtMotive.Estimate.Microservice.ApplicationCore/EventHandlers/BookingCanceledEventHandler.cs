using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Events;

namespace GtMotive.Estimate.Microservice.ApplicationCore.EventHandlers
{
    /// <summary>
    /// BookingCanceledEventHandler.
    /// </summary>
    public class BookingCanceledEventHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingCanceledEventHandler"/> class.
        /// </summary>
        public BookingCanceledEventHandler()
        {
            EventsRegister.BookingCanceled.Register(async parameter =>
            {
                // Handlimng of the event to execute additional process or for publish any integration event
                await Task.CompletedTask;
            });
        }
    }
}
