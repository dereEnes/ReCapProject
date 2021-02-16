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
        static CarManager carManager = new CarManager(new EfCarDal());
        static BrandManager brandManager = new BrandManager(new EfBrandDal());
        static ColorManager colorManager = new ColorManager(new EfColorDal());
        static void Main(string[] args)
        {
            ShowAll();
           //   Add();  
        }
        static void Add()
        {
            Color color1 = new Color() { Id = 3, Name = "Yellow" };
            
            colorManager.Add(color1);
            

            Brand brand1 = new Brand() { Id = 3, Name = "Volkswagen" };
            
            brandManager.Add(brand1);
            

            Car car1 = new Car() { Id = 5, BrandId = 3, ColorId = 3, DailyPrice = 75, Description = "25.000 km", ModelYear = 2014 };
            
            carManager.Add(car1);
            
        }
        private static void ShowAll()
        {
            Console.WriteLine("************ Cars **************");
            
            foreach (var car in carManager.GetCarDetailsDtos())
            {
                Console.WriteLine("id={0}  brand={1}  color={2}  dailyPrice={3}  ", car.Id, car.BrandName, car.ColorName, car.DailyPrice);
            }
            Console.WriteLine("******** Brands **************");
            

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("id={0}  Name={1}", brand.Id, brand.Name);
            }

            Console.WriteLine("******** Colors **************");
            

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("id={0}  Name={1}", color.Id, color.Name);
            }
        }
        
    }
}
