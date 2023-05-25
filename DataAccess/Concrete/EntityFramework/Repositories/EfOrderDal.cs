using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, OrderContext>, IOrderDal
    {
        public EfOrderDal(OrderContext context) : base(context)
        {

        }
    }
}
