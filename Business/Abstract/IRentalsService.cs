using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalsService
    {

        IDataResult<List<CarRentDetailDto>> GetCarRentDetails();
        //IDataResult<List<CarRentDetailDto>> GetCarRentDetail(int carId);
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rentals);
        IResult Update(Rental rentals);
        IResult Delete(Rental rentals);

        IResult IsCarEverRented(int carId);
        IResult IsCarReturned(int carId);
        IResult IsAvailableForRent(int carId);

        IDataResult<Rental> GetById(int Id);

    }
}
