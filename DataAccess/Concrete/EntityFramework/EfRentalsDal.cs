﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalsDal : EfEntitiyRepositoryBase<Rental, CarContext>, IRentalsDal
    {
        
        
    }
}