using AutoMapper;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mapper.AutoMapper
{
    class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<UpdateColorModel, Color>()
               .ForMember(dest=> dest.Name , opt => opt.MapFrom(src => src.Name));
        }
    }
}
