using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Guid Create(Order order);
        void Update(Order order);
        void Delete(Guid id);
        List<Order> GetAll();
        List<Order> GetAllByCustomerId(Guid id);
        Order GetById(Guid id);
        bool ChangeStatus(Guid id, string text);
    }
}
