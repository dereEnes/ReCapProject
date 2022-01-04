using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public void Add(AddCarModel model)
        {
            using (ReCapContext context = new ReCapContext())
            {
                context.Add(model);
                context.SaveChanges();
            }
        }

        public List<CarDetailsDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in filter==null ? context.Cars :context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join color in context.Colors
                             on c.ColorId equals color.Id
                             select new CarDetailsDto { Id = c.Id, BrandName = b.Name, ColorName = color.Name, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear };
                
                return result.ToList();
            }
        }
    }
}
