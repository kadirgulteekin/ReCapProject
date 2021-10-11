using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IRentalsService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rentals);
        IResult Update(Rental rentals);
        IResult Delete(Rental rentals);

        IDataResult<Rental> GetById(int Id);

    }
}
