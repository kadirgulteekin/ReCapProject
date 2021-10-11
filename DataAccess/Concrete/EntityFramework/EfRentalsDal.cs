using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalsDal : EfEntitiyRepositoryBase<Rental, CarContext>, IRentalsDal
    {
        public List<CarRentDetailDto> GetCarRentDetailByCar(int carId)
        {
            var resultlist = GetRentalDetails();
            return resultlist.Where(c => c.CarId == carId).ToList();

        }

        public List<CarRentDetailDto> GetRentalDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.Id equals r.CarId into temp
                             from t in temp.DefaultIfEmpty()
                             select new CarRentDetailDto { CarId = c.Id, RentalId = t.Id, ReturnDate = t.ReturnDate };



                return result.ToList();
            }
        }
    }
}
