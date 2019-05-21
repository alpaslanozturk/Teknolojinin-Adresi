using System;
using System.Collections.Generic;
using System.Text;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Entities.Concrete;
using TeknolojininAdresi.Repository.Abstract;

namespace TeknolojininAdresi.Business.Concrete
{
    public class OrdersService : IOrdersService
    {
        private IOrdersRepository _repOrder;

        public OrdersService(IOrdersRepository repOrder)
        {
            _repOrder = repOrder;
        }

        public void CompleteOrder(int userId, int cartsId, Orders order)
        {
            order.CartsId = cartsId;
            order.UsersId = userId;
            _repOrder.Add(order);
        }
    }
}
