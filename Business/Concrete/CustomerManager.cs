using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public Guid Create(Customer customer)
        {
            _customerDal.CreateAsync(customer);
            return customer.Id;
        }

        public void Delete(Guid id)
        {
            var customer = GetById(id);

            if(customer != null)
            {
                _customerDal.Delete(customer);
            }
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAllQueryable().ToList();
        }

        public Customer GetById(Guid id)
        {
            Customer customer = _customerDal.GetAsync(x => x.Id == id).Result;
            return customer;
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }

        public bool Validate(Guid id)
        {
            Customer customer = _customerDal.GetAsync(x => x.Id == id).Result;

            if(customer != null)
            {

            }
            return false;
        }
    }
}
