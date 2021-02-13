using Business.Concrete;
using System;
using DataAccess.Concrete.InMemory;
using System.Collections.Generic;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            List<Car> cars= carManager.GetAll();

            Console.WriteLine("*********** GetALL ***********");
            foreach (var car in cars)
            {
                Console.WriteLine("Id={0} ColorId={1} BrandId={2} ModelYear={3} DailyPrice={4} Description={5}",car.Id,car.ColorId,car.BrandId,car.ModelYear,car.DailyPrice,car.Description);
            }
            
            Car newCar = new Car() { BrandId=3,ColorId=5,Id=6,DailyPrice=250,Description="Toyoto",ModelYear=2015};
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
            carManager.Update(new Car() {Id=1,BrandId=1,ColorId=1,DailyPrice=1000,Description="Updated Car",ModelYear=2020 });
            cars = carManager.GetAll();
            Console.WriteLine("*********** Update ***********");
            foreach (var car in cars)
            {
                Console.WriteLine("Id={0} ColorId={1} BrandId={2} ModelYear={3} DailyPrice={4} Description={5}", car.Id, car.ColorId, car.BrandId, car.ModelYear, car.DailyPrice, car.Description);
            }

            Car GotById = carManager.GetById(3);
            Console.WriteLine("*********** GetById ***********");
            
                Console.WriteLine("Id={0} ColorId={1} BrandId={2} ModelYear={3} DailyPrice={4} Description={5}", GotById.Id, GotById.ColorId, GotById.BrandId, GotById.ModelYear, GotById.DailyPrice, GotById.Description);
            


            Console.WriteLine();
        }
    }
}
