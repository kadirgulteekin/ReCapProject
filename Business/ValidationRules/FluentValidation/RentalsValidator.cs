using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalsValidator : AbstractValidator<Rental>
    {
        public RentalsValidator()
        {
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.RentDate).NotEmpty();
            RuleFor(p => p.ReturnDate).NotEmpty();
            RuleFor(p => p.CustomerId).NotEmpty();
        

        }
    }
}
