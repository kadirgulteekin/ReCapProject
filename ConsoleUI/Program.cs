using Business.Concrete;
using Business.Constants;
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
            //GetCarDetails();
            AddRents();
            //AddUser();


        }

        private static void AddUser()
        {
            User user = new User { FirstName = "Kadir", LastName = "Gültekin", Email = "kadirgulteekin@gmail.com", Password = "1234" };
            UsersManager usersManager = new UsersManager(new EfUsersDal());

            var result = usersManager.Add(user);
            if (result.Success == true)
            {

                Console.WriteLine(result.Message);
                Console.WriteLine(user.FirstName + " " + user.LastName + " " + user.Email + " " + user.Password);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddRents()
        {
            RentalsManager rentalManager = new RentalsManager(new EfRentalsDal());
            Rental rental = new Rental { CarId = 1, CustomerId = 2, RentDate = new DateTime(2021, 10, 6) };
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);
        }

        private static void GetCarDetails()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            var result = carManager1.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static CarManager CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());


            foreach (var car in carManager.GetByUnitPrice(40, 100).Data)
            {
                Console.WriteLine(car.Description);
            }

            return carManager;
        }
    }
}
