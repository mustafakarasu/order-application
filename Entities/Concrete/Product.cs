using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product : BaseEntity, IEntity
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual List<ProductOrder> ProductOrders { get; set; }

        public Product()
        {
            ProductOrders = new List<ProductOrder>();
        }

    }
}
