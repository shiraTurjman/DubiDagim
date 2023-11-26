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
    public class CuttingShapePerItemRepository : ICuttingShapePerItemRepository
    {
        private readonly IDbContextFactory<ServerDbContext> _factory;
        public CuttingShapePerItemRepository(IDbContextFactory<ServerDbContext> factory)
        {
            _factory = factory;
        }
        public async Task AddCuttingShapePerItemAsync(CuttingShapePerItemEntity cuttingShapePerItem)
        {
            using var context = _factory.CreateDbContext();
            await context.CuttingShapePerItem.AddAsync(cuttingShapePerItem);
            
        }

       public async Task DeleteCuttingShapePerItemByCuttingShapeIdAsync(int cuttingShapeId)
        {
            using var context = _factory.CreateDbContext();
            List<CuttingShapePerItemEntity> cuttingItemToDelete = await context.CuttingShapePerItem.Where(i => i.CuttingShapeId == cuttingShapeId).ToListAsync();
            if (cuttingItemToDelete != null)
            {
                foreach (var item in cuttingItemToDelete)
                {
                    context.Remove(item);
                }
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Couldn't delete.");
            }

        }

        public async Task DeleteCuttingShapePerItemByItemIdAndCuttinIdAsync(int itemId, int cuttingShapeId)
        {

            using var context = _factory.CreateDbContext();
            CuttingShapePerItemEntity cuttingItemToDelete =  context.CuttingShapePerItem.Where(i => i.CuttingShapeId == cuttingShapeId && i.CuttingShapeId==cuttingShapeId).FirstOrDefault();

            if (cuttingItemToDelete != null)
            {
                context.Remove(cuttingItemToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Could not delete.");
            }
        }

        public async Task DeleteCuttingShapePerItemByItemIdAsync(int itemId)
        {
            using var context = _factory.CreateDbContext();
            List<CuttingShapePerItemEntity> cuttingItemToDelete = await context.CuttingShapePerItem.Where(i => i.ItemId == itemId).ToListAsync();
            if (cuttingItemToDelete != null)
            {
                foreach (var item in cuttingItemToDelete)
                {
                    context.Remove(item);
                }
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Couldn't delete.");
            }
        }

        public async Task<List<CuttingShapePerItemEntity>> GetAllCuttingShapePerItemByItemIdAsync(int itemId)
        {
            using var context = _factory.CreateDbContext();
            var list = await context.CuttingShapePerItem.Where(o => o.ItemId == itemId).ToListAsync();
            return list;
        }
    }
}
