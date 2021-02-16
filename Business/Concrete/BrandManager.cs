using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _BrandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _BrandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            _BrandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _BrandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _BrandDal.GetAll();
        }

        public Brand GetByBrandId(int brandId)
        {
            return _BrandDal.Get(b=>b.Id==brandId);
        }

        public void Update(Brand brand)
        {
            _BrandDal.Update(brand);
        }
    }
}
