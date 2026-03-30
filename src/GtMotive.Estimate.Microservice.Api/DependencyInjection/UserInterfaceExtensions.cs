using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Find;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.List;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Register;
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

            return services;
        }
    }
}
