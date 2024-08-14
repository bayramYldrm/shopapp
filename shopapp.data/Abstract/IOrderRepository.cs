using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetOrders(string userId);
        void OrderUpdate(Order entity);
        void OrderDelete(Order entity);
        Order GetOrdersById(int orderId);
        List<Order> GetAllOrders();
        
    }
}