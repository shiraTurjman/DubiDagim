using Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface ISaleRepository
    {
        Task AddSaleAsync(SaleEntity sale);
        Task DeleteSaleAsync(int saleId);
        Task DeleteSaleByItemIdAsync(int itemId);
        Task UpdateSaleAsync(SaleEntity sale);

        Task<List<SaleEntity>> GetAllSaleAsync();

        Task<List<SaleEntity>> GetSaleByItemIdAsync(int itemId);
    }
}
