﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IDataResult<Customer> GetById(int id);
     
        IResult Add(Customer customers);
        IResult Update(Customer customers);
        IResult Delete(Customer customers);

       

    }
}
