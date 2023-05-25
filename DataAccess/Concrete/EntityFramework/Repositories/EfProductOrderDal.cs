using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfProductOrderDal : EfEntityRepositoryBase<ProductOrder,OrderContext>, IProductOrderDal
    {
        public EfProductOrderDal(OrderContext context) : base(context)
        {

        }
    }
}
