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
    public class CuttingShapePerItemService : ICuttingShapePerItemService
    {
        private readonly ICuttingShapePerItemRepository _cuttingShapePerItemRepository ;

        public CuttingShapePerItemService(ICuttingShapePerItemRepository cuttingShapePerItemRepository)
        {
            _cuttingShapePerItemRepository = cuttingShapePerItemRepository ;
        }

        public async Task AddCuttingShapePerItemAsync(CuttingShapePerItemEntity cuttingShapePerItem)
        {
            await _cuttingShapePerItemRepository.AddCuttingShapePerItemAsync(cuttingShapePerItem);
        }

        public async Task DeleteCuttingShapePerItemByCuttingShapeIdAsync(int cuttingShapeId)
        {
            await _cuttingShapePerItemRepository.DeleteCuttingShapePerItemByCuttingShapeIdAsync(cuttingShapeId);
        }

        public async Task DeleteCuttingShapePerItemByItemIdAndCuttinIdAsync(int itemId, int cuttingShapeId)
        {
            await _cuttingShapePerItemRepository.DeleteCuttingShapePerItemByItemIdAndCuttinIdAsync(itemId, cuttingShapeId);
        }

        public async Task DeleteCuttingShapePerItemByItemIdAsync(int itemId)
        {
            await _cuttingShapePerItemRepository.DeleteCuttingShapePerItemByItemIdAsync(itemId);
        }

        public async Task<List<CuttingShapeEntity>> GetAllCuttingShapePerItemByItemIdAsync(int itemId)
        {

            return await _cuttingShapePerItemRepository.GetAllCuttingShapePerItemByItemIdAsync(itemId);
        }
    }
}
