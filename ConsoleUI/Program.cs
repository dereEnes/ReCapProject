using Business.Concrete;
using System;
using DataAccess.Concrete.InMemory;
using System.Collections.Generic;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
           // InMemory();
            CarManager carManager = new CarManager(new EfCarDal());
            Car car2 = new Car() { BrandId = 1, ColorId = 2, DailyPrice = -300, Description = "11", ModelYear = 2018, Id = 4 };

            carManager.Add(car2);
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("id = {0}   price = {1}  Yıl={2} ",car.Id,car.DailyPrice,car.ModelYear);
            }
            Console.WriteLine("/////////////////////////////////////");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("id = {0}   price = {1}  Yıl={2} ", car.Id, car.DailyPrice, car.ModelYear);
            }

             
            
        }

        private static void InMemory()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            List<Car> cars = carManager.GetAll();

            Console.WriteLine("*********** GetALL ***********");
            foreach (var car in cars)
            {
                Console.WriteLine("Id={0} ColorId={1} BrandId={2} ModelYear={3} DailyPrice={4} Description={5}", car.Id, car.ColorId, car.BrandId, car.ModelYear, car.DailyPrice, car.Description);
            }

            Car newCar = new Car() { BrandId = 3, ColorId = 5, Id = 6, DailyPrice = 250, Description = "Toyoto", ModelYear = 2015 };
            carManager.Add(newCar);
            cars = carManager.GetAll();
            Console.WriteLine("*********** Add ***********");
            foreach (var car in cars)
            {
                Console.WriteLine("Id={0} ColorId={1} BrandId={2} ModelYear={3} DailyPrice={4} Description={5}", car.Id, car.ColorId, car.BrandId, car.ModelYear, car.DailyPrice, car.Description);
            }

            carManager.Delete(newCar);
            cars = carManager.GetAll();
            Console.WriteLine("*********** Delete ***********");
            foreach (var car in cars)
            {
                Console.WriteLine("Id={0} ColorId={1} BrandId={2} ModelYear={3} DailyPrice={4} Description={5}", car.Id, car.ColorId, car.BrandId, car.ModelYear, car.DailyPrice, car.Description);
            }
            carManager.Update(new Car() { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 1000, Description = "Updated Car", ModelYear = 2020 });
            cars = carManager.GetAll();
            Console.WriteLine("*********** Update ***********");
            foreach (var car in cars)
            {
                Console.WriteLine("Id={0} ColorId={1} BrandId={2} ModelYear={3} DailyPrice={4} Description={5}", car.Id, car.ColorId, car.BrandId, car.ModelYear, car.DailyPrice, car.Description);
            }

            List<Car> GotById = carManager.GetCarsByBrandId(3);
            Console.WriteLine("*********** GetById ***********");

            foreach (var car in GotById)
            {
                Console.WriteLine("Id={0} ColorId={1} BrandId={2} ModelYear={3} DailyPrice={4} Description={5}", car.Id, car.ColorId, car.BrandId, car.ModelYear, car.DailyPrice, car.Description);
            }
        }
    }
}
