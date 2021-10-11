using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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
            _rentalsDal.Add(rentals);
            return new SuccessResult(Messages.RentsAdded);
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

        

        
        public IResult Update(Rental rentals)
        {
            _rentalsDal.Update(rentals);
            return new SuccessResult(Messages.RentsUpdated);
        }
    }
}
