using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderCreateDto
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalAmount { get; set; }

    }
}
