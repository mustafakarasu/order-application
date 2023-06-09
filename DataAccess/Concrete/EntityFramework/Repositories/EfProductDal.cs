﻿using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfProductDal : EfEntityRepositoryBase<Product,OrderContext>, IProductDal
    { 
        public EfProductDal(OrderContext context) : base(context)
        {
           
        }
    }
}
