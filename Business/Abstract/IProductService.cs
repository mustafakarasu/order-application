using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Guid Create(Product product);
        Product GetById(Guid id);
        void Delete(Product product);

    }
}
