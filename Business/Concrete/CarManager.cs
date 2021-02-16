using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
            if (car.Description.Length<2)
            {
                Console.WriteLine("Arabanın ismi mininun 2 karakter olmalı");
                return;
            }
            if (car.DailyPrice<0)
            {
                Console.WriteLine("Günlük fiyatı 0 dan büyük olmalı");
                return;
            }
            _ProductDal.Add(car);
        }

        public void Delete(Car car)
        {
            _ProductDal.Delete(car);
        }
        public void Update(Car car)
        {
            _ProductDal.Update(car);
        }
        public List<Car> GetAll()
        {
            return _ProductDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _ProductDal.GetAll(p=>p.BrandId==id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _ProductDal.GetAll(p=>p.ColorId==id);
        }

        public List<CarDetailsDto> GetCarDetailsDtos()
        {
            return _ProductDal.GetCarDetails();
        }
    }
}
