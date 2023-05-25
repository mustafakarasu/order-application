using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, OrderContext>, ICustomerDal
    {
        public EfCustomerDal(OrderContext context) : base(context)
        {
        }
    }
}
