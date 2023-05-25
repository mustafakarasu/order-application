using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Guid Create(Product product)
        {
            _productDal.CreateAsync(product);
            return product.Id;
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAllQueryable().ToList();
        }

        public Product GetById(Guid id)
        {
            return _productDal.GetAsync(x => x.Id == id).Result;
        }
    }
}
