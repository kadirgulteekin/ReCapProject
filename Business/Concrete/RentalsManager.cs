using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {

        IRentalsDal _rentalsDal;

        public RentalsManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        public IResult Add(Rental rentals)
        {
            var result = IsAvailableForRent(rentals.CarId);
            if (result.Success)
            {
                _rentalsDal.Add(rentals);
                return new SuccessResult(Messages.RentsAdded);
            }
            else
            {
                return new ErrorResult(result.Message);
            }
        }

        public IResult Delete(Rental rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult(Messages.RentsDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintananceTime);
            }

            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalsDal.Get(p => p.Id == Id));
        }

        public IDataResult<List<CarRentDetailDto>> GetCarRentDetails()
        {
            return new SuccessDataResult<List<CarRentDetailDto>>(_rentalsDal.GetCarRentDetails());
        }

        //public IDataResult<List<CarRentDetailDto>> GetCarRentDetail(int carId)
        //{
        //    return new SuccessDataResult<List<CarRentDetailDto>>(_rentalsDal.GetCarRentDetailByCarId(carId));
        //}

        public IResult IsAvailableForRent(int carId)
        {
            if (IsCarEverRented(carId).Success)
            {
                if (IsCarReturned(carId).Success)
                {
                    return new SuccessResult(Messages.RentsAdded);
                }
                return new ErrorResult(Messages.RentsUnAveliable);
            }
            return new SuccessResult(Messages.RentsAdded);
        }

        public IResult IsCarEverRented(int carId)
        {
            if (_rentalsDal.GetAll(r => r.CarId == carId).Any())
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult IsCarReturned(int carId)
        {
            if (_rentalsDal.GetAll(r => (r.CarId == carId) && (r.ReturnDate == null)).Any())
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IResult Update(Rental rentals)
        {
            _rentalsDal.Update(rentals);
            return new SuccessResult(Messages.RentsUpdated);
        }

        
    }
}
