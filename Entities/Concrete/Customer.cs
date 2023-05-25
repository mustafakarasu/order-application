using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : BaseEntity, IEntity
    {   
        [Display(Name="Ad")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        
        public List<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }

    }
}
