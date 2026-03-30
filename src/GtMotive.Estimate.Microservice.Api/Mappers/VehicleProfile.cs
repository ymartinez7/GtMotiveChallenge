using System;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Find;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Register;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Find;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Register;

namespace GtMotive.Estimate.Microservice.Api.Mappers
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<RegisterVehicleRequest, RegisterVehicleInput>();

            CreateMap<GetVehicleRequest, GetVehicleInput>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id ?? Guid.Empty));
        }
    }
}
