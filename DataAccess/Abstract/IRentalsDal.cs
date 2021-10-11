using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalsDal:IEntityRepository<Rental>
    {
        List<CarRentDetailDto> GetRentalDetails();
        List<CarRentDetailDto> GetCarRentDetailByCar(int carId);
    }
}
