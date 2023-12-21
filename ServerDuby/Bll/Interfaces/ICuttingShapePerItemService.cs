using Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface ICuttingShapePerItemService
    {
        Task AddCuttingShapePerItemAsync(CuttingShapePerItemEntity cuttingShapePerItem);
        Task DeleteCuttingShapePerItemByItemIdAndCuttinIdAsync(int itemId, int cuttingShapeId);
        Task DeleteCuttingShapePerItemByItemIdAsync(int itemId);
        Task DeleteCuttingShapePerItemByCuttingShapeIdAsync(int cuttingShapeId);
        Task<List<CuttingShapeEntity>> GetAllCuttingShapePerItemByItemIdAsync(int itemId);
    }
}
