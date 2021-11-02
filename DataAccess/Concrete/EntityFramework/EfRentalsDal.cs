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
  
        public List<CarRentDetailDto> GetCarRentDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.CarId equals r.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cs in context.Customers
                             on r.CustomerId equals cs.Id
                             join us in context.Users
                             on cs.UserId equals us.UserId

                             select new CarRentDetailDto 
                             {
                                 BrandName = b.BrandName,
                                 FullName = us.FirstName + " " + us.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };



                return result.ToList();
            }
        }
    }
}
