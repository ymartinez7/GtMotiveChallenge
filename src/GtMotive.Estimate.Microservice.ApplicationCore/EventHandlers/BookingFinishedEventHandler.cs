using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Events;

namespace GtMotive.Estimate.Microservice.ApplicationCore.EventHandlers
{
    /// <summary>
    /// BookingFinishedEventHandler.
    /// </summary>
    public class BookingFinishedEventHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingFinishedEventHandler"/> class.
        /// </summary>
        public BookingFinishedEventHandler()
        {
            EventsRegister.BookingFinished.Register(async parameter =>
            {
                // Handlimng of the event to execute additional process or for publish any integration event
                await Task.CompletedTask;
            });
        }
    }
}
