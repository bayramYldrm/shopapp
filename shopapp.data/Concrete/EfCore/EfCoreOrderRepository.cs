using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order, ShopContext>, IOrderRepository
    {
        public List<Order> GetOrders(string userId)
        {
            using(var context = new ShopContext())
            {

                var orders = context.Orders
                                    .Include(i=>i.OrderItems)
                                    .ThenInclude(i=>i.Product)
                                    .AsQueryable();

                if(!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(i=>i.UserId ==userId);
                }

                return orders.ToList();
            }
        }

        public Order GetOrdersById(int orderId)
        {
               using (var context = new ShopContext())
                {
                    // Veritabanından belirli bir siparişin ID'sine göre ilgili siparişi al
                    return  context.Orders
                                    .Where(i=>i.Id == orderId)
                                    .Include(i=>i.OrderItems)
                                    .ThenInclude(i=>i.Product)
                                    .FirstOrDefault();

                }
        }

        public void OrderDelete(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public void OrderUpdate(Order entity)
        {
            using (var context = new ShopContext())
            {
                var existingOrder = context.Orders.Find(entity.Id);
                if (existingOrder != null)
                {
                    existingOrder.Phone = entity.Phone;
                    existingOrder.FirstName = entity.FirstName;
                    existingOrder.LastName = entity.LastName;
                    existingOrder.Email = entity.Email;
                    existingOrder.Address = entity.Address;
                    existingOrder.City = entity.City;
                    existingOrder.OrderState = entity.OrderState;
                    existingOrder.PaymentType = entity.PaymentType;
                    existingOrder.OrderState2 = entity.OrderState2;
                    existingOrder.DeliveryDate = entity.DeliveryDate;
                    existingOrder.ShippingCompany = entity.ShippingCompany;
                    existingOrder.OrderNotes = entity.OrderNotes;

                    context.SaveChanges();
                }
            }
        }

        public List<Order> GetAllOrders()
        {
            using(var context = new ShopContext())
            {
                var orders = context.Orders
                                    .Include(i => i.OrderItems)
                                        .ThenInclude(i => i.Product)
                                    .ToList();

                return orders;
            }
        }
    }
}