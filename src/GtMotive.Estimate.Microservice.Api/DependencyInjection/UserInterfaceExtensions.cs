using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Cancel;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Finish;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.GetDetails;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.MakeNew;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Pay;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Find;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.List;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Register;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Cancel;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Finish;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.GetDetails;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.MakeNew;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Pay;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Find;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.List;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Register;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            // Vehicles
            services.AddSingleton<GetVehiclePresenter>();
            services.AddSingleton<ListVehiclesPresenter>();
            services.AddSingleton<RegisterVehiclePresenter>();
            services.AddSingleton<IGetVehicleOutputPort>(provider => provider.GetRequiredService<GetVehiclePresenter>());
            services.AddSingleton<IListVehiclesOutputPort>(provider => provider.GetRequiredService<ListVehiclesPresenter>());
            services.AddSingleton<IRegisterVehicleOutputPort>(provider => provider.GetRequiredService<RegisterVehiclePresenter>());

            // Bookings
            services.AddSingleton<MakeNewBookingPresenter>();
            services.AddSingleton<GetBookingDetailsPresenter>();
            services.AddSingleton<PayBookingPreseter>();
            services.AddSingleton<CancelBookingPresenter>();
            services.AddSingleton<FinishBookingPresenter>();
            services.AddSingleton<IMakeNewBookingOutputPort>(provider => provider.GetRequiredService<MakeNewBookingPresenter>());
            services.AddSingleton<IGetBookingDetailsOutputPort>(provider => provider.GetRequiredService<GetBookingDetailsPresenter>());
            services.AddSingleton<IPayBookingOutputPort>(provider => provider.GetRequiredService<PayBookingPreseter>());
            services.AddSingleton<ICancelBookingOutputPort>(provider => provider.GetRequiredService<CancelBookingPresenter>());
            services.AddSingleton<IFinishBookingOutputPort>(provider => provider.GetRequiredService<FinishBookingPresenter>());

            return services;
        }
    }
}
