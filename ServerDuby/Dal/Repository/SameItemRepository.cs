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
    public class SameItemRepository : ISameItemRepository
    {
        private readonly IDbContextFactory<ServerDbContext> _factory;
        public SameItemRepository(IDbContextFactory<ServerDbContext> factory) 
        {
            _factory = factory; 
        }

        public async Task AddSameItemAsync(SameItemEntity sameItem)
        {
            using var context = await _factory.CreateDbContextAsync();
            context.SameItems.Add(sameItem);
            await context.SaveChangesAsync();

        }

        public async Task DeleteSameItemByItemIdAsync(int itemId)
        {
            using var context = await _factory.CreateDbContextAsync();
            var sameItemDelete = await context.SameItems.Where(s => s.ItemAId==itemId || s.ItemBId==itemId).ToListAsync();
            if (sameItemDelete != null)
            {
                foreach (var item in sameItemDelete)
                {
                    context.SameItems.Remove(item);
                }
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("same item to delete by item id not found");
            }

        }

        public async Task DeleteSameItemBySameItemIdAsync(int sameItemId)
        {
           using var context= await _factory.CreateDbContextAsync();
            var sameItemToDelete= await context.SameItems.FirstOrDefaultAsync(s=>s.SameItemId==sameItemId);
            if (sameItemToDelete != null)
            {
                context.SameItems.Remove(sameItemToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("same item not found");
            }
        }

       public async Task<List<SameItemEntity>>GetSameItemByItemId(int itemId)
        {
            using var context = await _factory.CreateDbContextAsync();
            var sameItem = await context.SameItems.Where(s => s.ItemAId == itemId || s.ItemBId == itemId).ToListAsync();
            if (sameItem != null)
            {
                return sameItem;
            }
            else
            {
                throw new Exception("same item not found");
            }
        }

        public async Task<SameItemEntity> GetSameItemByTwoItemId(int itemAId, int ItemBId)
        {
            using var context = await _factory.CreateDbContextAsync();
            var sameItem = await context.SameItems.FirstOrDefaultAsync(s => (s.ItemAId == itemAId && s.ItemBId == ItemBId) || (s.ItemAId == ItemBId && s.ItemBId == itemAId));
            if (sameItem != null)
            {
                return sameItem;
            }
            else {
                throw new Exception("same item not found");
            }
        }
    }
}
