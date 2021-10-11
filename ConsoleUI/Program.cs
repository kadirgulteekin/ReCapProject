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
            //AddRents();
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
            Rental rental = new Rental { CarId = 3, CustomerId = 1, RentDate = DateTime.Now };

            RentalsManager rentalManager = new RentalsManager(new EfRentalsDal());
            var result = rentalManager.Add(rental);
            if (result.Success == true)
            {

                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
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
