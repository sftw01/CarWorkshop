using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Application.Mapping
{
    public class CarWorkshopMappingProfile : Profile
    {

        public CarWorkshopMappingProfile()
        {
            //map CarWorkshop to CarWorkshopDto
            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street
                }
                ));

            //map CarWorkshopDto to CarWorkshop
            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(dto => dto.Street, opt => opt.MapFrom(scr => scr.ContactDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(scr => scr.ContactDetails.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(scr => scr.ContactDetails.PostalCode))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(scr => scr.ContactDetails.PhoneNumber));

        }
    }
}
