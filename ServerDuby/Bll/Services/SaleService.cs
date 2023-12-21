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
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        public SaleService(ISaleRepository saleRepository) {
            _saleRepository = saleRepository;        
        }

        public async Task AddSaleAsync(SaleEntity sale)
        {
            await _saleRepository.AddSaleAsync(sale);
        }

        public async Task DeleteSaleAsync(int saleId)
        {
            await _saleRepository.DeleteSaleAsync(saleId);
        }

        public async Task DeleteSaleByItemIdAsync(int itemId)
        {
            await _saleRepository.DeleteSaleByItemIdAsync(itemId);
        }

        public async Task<List<SaleEntity>> GetAllSaleAsync()
        {
            return await _saleRepository.GetAllSaleAsync();
        }

        public async Task<List<SaleEntity>> GetSaleByItemIdAsync(int itemId)
        {
            return await _saleRepository.GetSaleByItemIdAsync(itemId);
        }

        public async Task UpdateSaleAsync(SaleEntity sale)
        {
            await _saleRepository.UpdateSaleAsync(sale);
        }
    }
}
