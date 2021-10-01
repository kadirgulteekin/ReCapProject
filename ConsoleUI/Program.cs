using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
          
            //carmanager carmanager = cartest();
           
            CarManager carManager1 = new CarManager(new EfCarDal());
     
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand {BrandName = "Mercedes" });
            //foreach (var  brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Pink" });
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}
            carManager1.Update(new Car { Id = 1006, DailyPrice = 159753000,ColorId=2,BrandId=1002,ModelYear=2021,Description="S90"});
            foreach (var car in carManager1.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }


           

        }

        private static CarManager CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());


            foreach (var car in carManager.GetByUnitPrice(40, 100))
            {
                Console.WriteLine(car.Description);
            }

            return carManager;
        }
    }
}
