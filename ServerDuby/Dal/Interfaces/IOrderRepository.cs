using Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(OrderEntity order);
        Task UpdateOrderAsync(OrderEntity order);
        Task DeleteOrderByOrderIdAsync(int orderId);
        Task DeleteOrderByUserIdAsync(int userId);

        Task<List<OrderEntity>> GetAllOrderByUserIdAsync(int userId);
        Task<OrderEntity> GetOrderByOrderIdAsync(int orderId);

        Task<int> GetOrderIdForShoppingCardAsync(int userId);

        Task UpdateIsShoppingCard(int userId);
    }
}
