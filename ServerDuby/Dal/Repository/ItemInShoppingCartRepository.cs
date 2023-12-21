using Dal.Entity;
using Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class ItemInShoppingCartRepository : IItemInShoppingCartRepository
    {
        private readonly IDbContextFactory<ServerDbContext> _factory;
        public ItemInShoppingCartRepository(IDbContextFactory<ServerDbContext> factory) { 
        
        _factory=factory;
               }

        public async Task AddItemToOrder(ItemInShoppingCartEntity item)
        {
           using var context=_factory.CreateDbContext();
            await context.ItemInShoppingCarts.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAllItemInOrder(int orderId)
        {
           using var context = _factory.CreateDbContext();
            var itemToDelete= await context.ItemInShoppingCarts.Where(o=>o.OrderId==orderId).ToListAsync();
            if (itemToDelete != null)
            {
                foreach (var item in itemToDelete)
                {
                    context.ItemInShoppingCarts.Remove(item);
                }
                await context.SaveChangesAsync();
            }
            else {
                throw new Exception("items in this order not found");
            }
        }

        public async Task DeleteItemFromOrder(int itemInShoppingId)
        {
            using var context= _factory.CreateDbContext();
            var itemToDelete = await context.ItemInShoppingCarts.FirstOrDefaultAsync(i=>i.ItemInShoppingCartId== itemInShoppingId);
            if (itemToDelete != null)
            {
                context.ItemInShoppingCarts.Remove(itemToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("item in order to delete not found");
            }
        }

        public async Task<List<ItemInShoppingCartEntity>> GetItemInOrderByOrderId(int OrderId)
        {
            using var context = _factory.CreateDbContext();
            var list=await context.ItemInShoppingCarts.Where(o=>o.OrderId==OrderId).ToListAsync();
            if (list != null)
            {
                return list;
            }
            else {
                throw new Exception("item in this ordet not found");
            }
        }

        public async Task UpdateItemInOrder(ItemInShoppingCartEntity item)
        {
            using var context=_factory.CreateDbContext();
            var itemToUpdate = context.ItemInShoppingCarts.FirstOrDefault(i => i.ItemInShoppingCartId == item.ItemInShoppingCartId);
            if (itemToUpdate != null)
            {
                itemToUpdate.OrderId = item.OrderId;
                itemToUpdate.CuttingShapeId = item.CuttingShapeId;
                itemToUpdate.ItemId = item.ItemId;
                itemToUpdate.Amount = item.Amount;
                itemToUpdate.Details = item.Details;
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("item in order to update not found");
            }
        }
    }
}
