using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarRentDetailDto:IDto
    {
        public int RentalId { get; set; }
        public string BrandName { get; set; }
        public string FullName { get; set; }
        public Nullable<DateTime> RentDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
    }
}
