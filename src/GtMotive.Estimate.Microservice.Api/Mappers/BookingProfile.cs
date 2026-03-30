using System;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Pay;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Pay;

namespace GtMotive.Estimate.Microservice.Api.Mappers
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<PayBookingRequest, PayBookingInput>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id ?? Guid.Empty))
                .ForMember(dest => dest.PaymentDetails, opt => opt.MapFrom(src => src.PaymentDetails));

            CreateMap<PaymentDetailRequest, PaymentDetailInput>()
                .ForMember(dest => dest.Paymentype, opt => opt.MapFrom(src => src.Paymentype))
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.CardNumber))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate));

            CreateMap<PaymentypeRequest, PaymentypeInput>()
                .ConvertUsing(src => (PaymentypeInput)src);
        }
    }
}
