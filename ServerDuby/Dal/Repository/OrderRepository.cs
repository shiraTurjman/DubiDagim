using Dal.Entity;
using Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly IDbContextFactory<ServerDbContext> _factory;
        public OrderRepository(IDbContextFactory<ServerDbContext> factory)
        {
            _factory = factory;
        }

       public async Task AddOrderAsync(OrderEntity order)
        {
            using var context=_factory.CreateDbContext();
            await context.Orders.AddAsync(order);
            context.SaveChanges();
        }

        public async Task DeleteOrderByOrderIdAsync(int orderId)
        {
            using var dbContext=_factory.CreateDbContext();
            OrderEntity orderToDelete = await dbContext.Orders.FindAsync(orderId);
            if (orderToDelete != null)
            {
                dbContext.Orders.Remove(orderToDelete);
                await dbContext.SaveChangesAsync();
            }
            else {
                throw new Exception("this order to delete not found");
            }

        }

        public async Task DeleteOrderByUserIdAsync(int userId)
        {
           using var context= _factory.CreateDbContext();
            var list = await context.Orders.Where(o=>o.UserId==userId).ToListAsync();
            if (list != null)
            {
                foreach (var order in list)
                {
                    context.Orders.Remove(order);
                }
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("order not found");
            }
        }

         public async Task<List<OrderEntity>> GetAllOrderByUserIdAsync(int userId)
        {
           using var context= _factory.CreateDbContext();
            List<OrderEntity> orders = await context.Orders.Where(o => o.UserId == userId && o.IsShoppingCart==false).ToListAsync();
            if (orders != null)
            {
                return orders;
            }
            else
            {
                throw new Exception("orders nor found");
            }
        }

        public async Task<OrderEntity> GetOrderByOrderIdAsync(int orderId)
        {
            using var dbContext = _factory.CreateDbContext();
            OrderEntity order = await dbContext.Orders.FindAsync(orderId);
            if (order != null)
            {
                return order;
            }
            else
            {
                throw new Exception("order not found");
            }

        }

        public async Task<int> GetOrderIdForShoppingCardAsync(int userId)
        {
            using var context= _factory.CreateDbContext();
            var order =  context.Orders.FirstOrDefault(o => o.UserId == userId && o.IsShoppingCart == true);
            if (order != null)
            {
                return order.OrderId;
            }
            else
            {
                throw new Exception("error shopping cart not found");
            }
        }

       public async Task UpdateOrderAsync(OrderEntity order)
        {
            using var dbContext = _factory.CreateDbContext();
            var orderToUpdate = dbContext.Orders.FirstOrDefault(i => i.OrderId == order.OrderId);
            if (orderToUpdate != null)
            {
                orderToUpdate.OrderDate = order.OrderDate;
                orderToUpdate.UserId = order.UserId;
                orderToUpdate.IsShoppingCart = order.IsShoppingCart;
                await dbContext.SaveChangesAsync();

            }
            else { throw new Exception("could not update order , order not found"); }
        }

        public async Task UpdateIsShoppingCard(int userId)
        {
            using var context = _factory.CreateDbContext();
            var order = context.Orders.FirstOrDefault(o => o.UserId == userId && o.IsShoppingCart == true);
            if (order != null)
            {
                order.IsShoppingCart = false;
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("error shopping cart not found");
            }
        }
    }

}
