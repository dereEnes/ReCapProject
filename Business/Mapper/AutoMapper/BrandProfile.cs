using AutoMapper;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mapper.AutoMapper
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<UpdateBrandModel, Brand>();
        }
    }
}
