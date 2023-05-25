using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductOrderManager : IProductOrderService
    {
        private IProductOrderDal _productOrderDal;
        public ProductOrderManager(IProductOrderDal productOrderDal)
        {
            _productOrderDal = productOrderDal;
        }
        public void Create(ProductOrder productOrder)
        {
            _productOrderDal.CreateAsync(productOrder);
        }
    }
}
