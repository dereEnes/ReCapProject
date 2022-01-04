using AutoMapper;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mapper.AutoMapper
{
    public class AddCarProfile:Profile
    {
        public AddCarProfile()
        {
            CreateMap<Car, AddCarModel>()
                .ForMember(dest => dest.BrandId,opt=> opt.MapFrom(src => src.BrandId))
                .ForMember(dest => dest.ColorId, opt => opt.MapFrom(src => src.ColorId))
                .ForMember(dest => dest.DailyPrice, opt => opt.MapFrom(src => src.DailyPrice))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.ModelYear));
        }
    }
}
