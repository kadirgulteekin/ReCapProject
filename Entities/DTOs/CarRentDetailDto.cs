using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarRentDetailDto:IDto
    {
        public int CarId { get; set; }
        public int RentalId { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
    }
}
