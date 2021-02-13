using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    class InMemoryProductDal : IProductDal
    {
        List<Car> _ListOfCar;
        public InMemoryProductDal()
        {
            _ListOfCar = new List<Car>() { 
                new Car {  Id = 1, BrandId=1,ColorId=1,DailyPrice=1500,Description="Bmw x series",ModelYear=2020},
                new Car {  Id = 2, BrandId=5,ColorId=2,DailyPrice=500,Description="Audi a8",ModelYear=2016},
                new Car {  Id = 3, BrandId=3,ColorId=2,DailyPrice=300,Description="Ford Mustang",ModelYear=2013},
                new Car {  Id = 4, BrandId=2,ColorId=5,DailyPrice=100,Description="Camaro",ModelYear=2010},
                new Car {  Id = 5, BrandId=7,ColorId=6,DailyPrice=600,Description="Tesla",ModelYear=2018}


            };
        }
        public void Add(Car car)
        {
            _ListOfCar.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _ListOfCar.FirstOrDefault(p=>p.Id==car.Id);
            _ListOfCar.Remove(CarToDelete);
        }

        public List<Car> GetAll()
        {
            return _ListOfCar;
        }

        public Car GetById(int id)
        {
            return _ListOfCar.FirstOrDefault(p=>p.Id==id);
        }

        public void Update(Car car)
        {
            Delete(car);
            Add(car);
        }
    }
}
