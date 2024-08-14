using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface IOrderService
    {
        Order GetOrdersById(int orderId);
        void Create(Order entity);
        List<Order> GetOrders(string userId);
        void OrderUpdate(Order entity);
        void OrderDelete(Order entity);

        List<Order> GetAllOrders();
    }
}