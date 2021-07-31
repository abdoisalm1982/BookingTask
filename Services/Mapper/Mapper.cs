using AutoMapper;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using  Services.ViewModels;

namespace Services.Mapper
{
   public class Mapper : Profile
    {
        public Mapper()
        {
            AllowNullDestinationValues = true;
            //Source -> Destination
          
            CreateMap<User, LoginModel>()
                .ForMember(dto => dto.UserEmail, opt => opt.MapFrom(src => src.Email))
               .ForMember(dto => dto.UserPassword, opt => opt.MapFrom(src => src.Password));
            CreateMap<Reservation, ReservationModel>()
         
            .ForMember(dto => dto.ReservedId, opt => opt.MapFrom(src => src.ReservedId))
                       .ForMember(dto => dto.ReservedBy, opt => opt.MapFrom(src => src.ReservedBy));

        }
    }
}
