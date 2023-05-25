using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProductOrder : BaseEntity, IEntity
    {
        public Guid ProductId { get; set; }
        //public Product Product { get; set; }

        public Guid OrderId { get; set; }
        //public Order Order { get; set; }
    }
}
