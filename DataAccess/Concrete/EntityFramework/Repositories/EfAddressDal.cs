using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfAddressDal : EfEntityRepositoryBase<Address,OrderContext>, IAddressDal
    {
        public EfAddressDal(OrderContext context) : base(context)
        {
            
        }
    }
}
