using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Guid Create(Customer customer);
        void Update(Customer customer);
        void Delete(Guid id);
        List<Customer> GetAll();
        Customer GetById(Guid id);
        bool Validate(Guid id);
    }
}
