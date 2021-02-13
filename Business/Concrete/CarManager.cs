using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _ProductDal;
        public CarManager(ICarDal productDal)
        {
            _ProductDal = productDal;
        }
        public void Add(Car car)
        {
            _ProductDal.Add(car);
        }

        public void Delete(Car car)
        {
            _ProductDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _ProductDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _ProductDal.GetById(id);
        }

        public void Update(Car car)
        {
            _ProductDal.Update(car);
        }
    }
}
