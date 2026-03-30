using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.ApplicationCore.EventHandlers;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Cancel;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Finish;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.GetDetails;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.MakeNew;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Pay;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Find;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.List;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Register;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            // Vehicles use cases
            services.AddScoped<IGetVehicleUseCase, GetVehicleUseCase>();
            services.AddScoped<IListVehiclesUseCase, ListVehiclesUseCase>();
            services.AddScoped<IRegisterVehicleUseCase, RegisterVehicleUseCase>();

            // Bookings use cases
            services.AddScoped<IMakeNewBookingUseCase, MakeNewBookingUseCase>();
            services.AddScoped<IGetBookingDetailsUseCase, GetBookingDetailsUseCase>();
            services.AddScoped<IPayBookingUseCase, PayBookingUseCase>();
            services.AddScoped<ICancelBookingUseCase, CancelBookingUseCase>();
            services.AddScoped<IFinishBookingUseCase, FinishBookingUseCase>();

            return services;
        }

        /// <summary>
        /// AddEventHandlers.
        /// </summary>
        /// <param name="services">services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddEventHandlers(this IServiceCollection services)
        {
            services.AddSingleton(new VehicleAddedEventHandler());
            services.AddSingleton(new BookingCreatedEventHandler());
            services.AddSingleton(new BookingConfirmedEventHandler());
            services.AddSingleton(new BookingCanceledEventHandler());
            services.AddSingleton(new BookingFinishedEventHandler());

            return services;
        }
    }
}
