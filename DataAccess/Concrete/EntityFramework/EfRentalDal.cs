using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join b in context.Brands
                             on r.CarId equals b.Id
                             join user in context.Users
                             on r.CustomerId equals user.Id
                             select new RentalDetailsDto { Id=r.Id,BrandName=b.Name,RentDate=r.RentDate,ReturnDate= (DateTime)r.ReturnDate, FirstName=user.FirstName,LastName=user.LastName };
                return result.ToList();
            }
        }
        public Rental CheckForAvailable(Expression<Func<Rental, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Rental>().LastOrDefault(filter);
            }
        }
    }
}
