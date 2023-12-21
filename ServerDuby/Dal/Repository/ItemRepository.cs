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
    public class ItemRepository : IItemRepository

    {
        private readonly IDbContextFactory<ServerDbContext> _factory;

        public ItemRepository (IDbContextFactory<ServerDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<int> AddItemAsync(ItemEntity item)
        {
            using var context = _factory.CreateDbContext();
            context.Items.Add(item);
            await context.SaveChangesAsync();
            var temp = await context.Items.FirstOrDefaultAsync(i => i.ItemId == item.ItemId);
            return temp.ItemId;
            
        }

       public async Task<int> DeleteItemAsync(int itemId)
        {
            using var dbContext = _factory.CreateDbContext();
            ItemEntity itemToDelete = await dbContext.Items.FindAsync(itemId);
            if (itemToDelete != null)
            {
                dbContext.Items.Remove(itemToDelete);
                await dbContext.SaveChangesAsync();
                return itemToDelete.ItemId;
            }

            else
            {
                throw new Exception("item not found");
            }
            
        }

       public async Task<List<ItemEntity>> GetAllItemAsync()
        {
            using var context = _factory.CreateDbContext();
            var list =await context.Items.ToListAsync();
            if (list != null)
            {
                return list;
            }
            else
            {
                throw new Exception("could not get items ");
            }
        }

        public async Task<List<ItemEntity>> GetItemByCategoryIdAsync(int categoryId)
        {
            using var context = _factory.CreateDbContext();
            var list = await context.Items.Where(i=>i.CategoryId==categoryId).ToListAsync();
            if (list != null)
            {
                return list;
            }
            else
            {
                throw new Exception("could not get Item by category");
            }
        }

         public async Task<ItemEntity> GetItemByItemIdAsync(int itemId)
        {
            using var dbContext = _factory.CreateDbContext();
            var item = dbContext.Items.FirstOrDefault(i=>i.ItemId==itemId);
            if (item == null) 
            {
                throw new Exception("could not find item");
            }
            return item;
        }

       public async Task UpdateItemAsync(ItemEntity item)
        {
            using var dbContext = _factory.CreateDbContext();
            var itemToUpdate = dbContext.Items.FirstOrDefault(i => i.ItemId == item.ItemId);
            if (itemToUpdate != null)
            {
                itemToUpdate.ItemName = item.ItemName;
                itemToUpdate.Price = item.Price;
                itemToUpdate.Details = item.Details;
                itemToUpdate.AverageSize = item.AverageSize;
                itemToUpdate.CategoryId = item.CategoryId;
                await dbContext.SaveChangesAsync();
                
            }
            else { throw new Exception("could not update item , item not found"); }
            
        }
    }
}
