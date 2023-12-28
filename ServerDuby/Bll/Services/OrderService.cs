using Bll.Interfaces;
using Dal.Entity;
using Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository) {
        _orderRepository = orderRepository;

        }

        public Task AddOrderAsync(OrderEntity order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderByOrderIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderEntity>> GetAllOrderByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderEntity> GetOrderByOrderIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetOrderIdForShoppingCardAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIsShoppingCard(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderAsync(OrderEntity order)
        {
            throw new NotImplementedException();
        }
    }
}
