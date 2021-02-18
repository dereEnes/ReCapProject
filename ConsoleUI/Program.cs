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
        static CustomerManager CustomerManager = new CustomerManager(new EfCustomerDal());
        static UserManager userManager = new UserManager(new EfUserDal());
        static void Main(string[] args)
        {
            // ShowAll();
            //   Add();  
            //User user = new User() { Email="selcuk@gmail.com",FirstName="kursat",LastName="eren",Id=3,Password="123456"};
            //userManager.Add(user);


            
            Rental rent = new Rental() {CarId=2,CustomerId=2,Id=2, RentDate = DateTime.Now.Date };
           // Rental rent2 = new Rental() { CarId = 2, CustomerId = 3, Id = 2, RentDate =new DateTime(2021,02,15) };
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var res1=rentalManager.Add(rent);
            Console.WriteLine(res1.Message);
         //   var res2 = rentalManager.Add(rent2);
            
            //Customer customer2 = new Customer() { Id = 2, UserId = 2, CompanyName = "Sahibinden" };
            //Customer customer3 = new Customer() { Id = 3, UserId = 3, CompanyName = "Akbank" };
            //Customer customer4 = new Customer() { Id = 4, UserId = 4, CompanyName = "TasıtCom" };
            //Customer customer5 = new Customer() { Id = 5, UserId = 5, CompanyName = "Google" };
            
            //CustomerManager.Add(customer2);
            //CustomerManager.Add(customer3);
            //CustomerManager.Add(customer4);
            //CustomerManager.Add(customer5);


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
            
            foreach (var car in carManager.GetCarDetailsDtos().Data)
            {
                Console.WriteLine("id={0}  brand={1}  color={2}  dailyPrice={3}  ", car.Id, car.BrandName, car.ColorName, car.DailyPrice);
            }
            Console.WriteLine("******** Brands **************");
            

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("id={0}  Name={1}", brand.Id, brand.Name);
            }

            Console.WriteLine("******** Colors **************");
            

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("id={0}  Name={1}", color.Id, color.Name);
            }
        }
        
    }
}
