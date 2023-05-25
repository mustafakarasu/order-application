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
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public bool ChangeStatus(Guid id, string text)
        {
            throw new NotImplementedException();
        }

        public Guid Create(Order order)
        {
            _orderDal.CreateAsync(order);
            return order.Id;
        }

        public void Delete(Guid id)
        {
            Order order = GetById(id);
            if (order != null)
            {
                _orderDal.Delete(order);
            }
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetAllQueryable().ToList();
        }

        public List<Order> GetAllByCustomerId(Guid id)
        {
            return _orderDal.GetAllQueryable(x => x.CustomerId == id).ToList();
        }

        public Order GetById(Guid id)
        {
            return _orderDal.GetAsync(x => x.Id == id).Result;
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
        }
    }
}
