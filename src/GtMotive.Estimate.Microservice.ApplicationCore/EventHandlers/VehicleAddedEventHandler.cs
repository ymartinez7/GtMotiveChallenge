using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Events;

namespace GtMotive.Estimate.Microservice.ApplicationCore.EventHandlers
{
    /// <summary>
    /// VehicleAddedEventHandler.
    /// </summary>
    public class VehicleAddedEventHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAddedEventHandler"/> class.
        /// VehicleAddedEventHandler.
        /// </summary>
        public VehicleAddedEventHandler()
        {
            EventsRegister.VehicleAdded.Register(async parameter =>
            {
                // Handlimng of the event to execute additional process or for publish any integration event
                await Task.CompletedTask;
            });
        }
    }
}
