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
    public class SaleRepository : ISaleRepository
    {
        private readonly IDbContextFactory<ServerDbContext> _factory;
        public SaleRepository(IDbContextFactory<ServerDbContext> factory) 
        {
            _factory = factory;
        }

        public async Task AddSaleAsync(SaleEntity sale)
        {
            using var context = await _factory.CreateDbContextAsync();
            await context.Sales.AddAsync(sale);
            await context.SaveChangesAsync();                                                                      

        }

        public async Task DeleteSaleAsync(int saleId)
        {
            using var context = await _factory.CreateDbContextAsync();
            SaleEntity saleToDelete=await context.Sales.FindAsync(saleId);
            if (saleToDelete != null)
            {
                context.Sales.Remove(saleToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("sale not found");
            }
        }

       public async Task DeleteSaleByItemIdAsync(int itemId)
        {
            using var context = await _factory.CreateDbContextAsync();
            var saleToDelete = await context.Sales.Where(o => o.ItemId == itemId).ToListAsync();
            if (saleToDelete != null)
            {
                foreach (var sale in saleToDelete)
                {
                    context.Sales.Remove(sale);
                }
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("sale not found");
            }
        }

        public async Task<List<SaleEntity>> GetAllSaleAsync()
        {

            using var context=await _factory.CreateDbContextAsync();
            List<SaleEntity> sales = await context.Sales.ToListAsync();
            if (sales != null)
            {
                return sales;
            }
            else
            {
                throw new Exception("sale not found");
            }
        }

        public async Task<List<SaleEntity>> GetSaleByItemIdAsync(int itemId)
        {
            using var context = await _factory.CreateDbContextAsync();
            var sale = await context.Sales.Where(i=>i.ItemId==itemId).ToListAsync();
            if(sale.Count==0)
            { return null; }
            if (sale != null)
            {
                return sale;
            }
            else
            {
                throw new Exception("sale not found");
            }
        }

        public async Task UpdateSaleAsync(SaleEntity sale)
        {
            using var context = await _factory.CreateDbContextAsync();
            var saleToUpdate = context.Sales.FirstOrDefault(s => s.SaleId == sale.SaleId);
            if (saleToUpdate != null)
            {
                saleToUpdate.ItemId = sale.ItemId;
                saleToUpdate.Percents = sale.Percents;
                saleToUpdate.NewPrice = sale.NewPrice;
                saleToUpdate.Amount = sale.Amount;
                saleToUpdate.Details = sale.Details;
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("sale to update not found");
            }
        }
    }
}
