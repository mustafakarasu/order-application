using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Order : BaseEntity, IEntity
    {
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }

        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        [Display(Name = "Tutar")]
        public double Price { get; set; }

        [Display(Name = "Sipariş Durumu")]
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public Customer Customer { get; set; }
        public Address Address { get; set; }


        public virtual List<ProductOrder> ProductOrders { get; set; }
        public Order()
        {
            ProductOrders = new List<ProductOrder>();
        }
    }
}
