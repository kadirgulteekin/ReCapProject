using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomersManager : ICustomerService
    {
        ICustomersDal _customersDal;

        public CustomersManager(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }

        public IResult Add(Customer customers)
        {
            if (customers.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInValid);
            }
            _customersDal.Add(customers);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Customer customers)
        {
            _customersDal.Delete(customers);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintananceTime);
            }

            return new SuccessDataResult<List<Customer>>(_customersDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customersDal.Get(p => p.UserId == id));
        }

        

        public IResult Update(Customer customers)
        {
            _customersDal.Update(customers);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
