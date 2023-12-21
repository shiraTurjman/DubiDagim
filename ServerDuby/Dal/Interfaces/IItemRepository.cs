using Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface IItemRepository
    {
        Task<int> AddItemAsync(ItemEntity item);
        Task UpdateItemAsync(ItemEntity item);
        Task<int> DeleteItemAsync(int itemId);

        Task<List<ItemEntity>> GetAllItemAsync();
        Task<List<ItemEntity>> GetItemByCategoryIdAsync(int categoryId);
        Task<ItemEntity> GetItemByItemIdAsync(int itemId);

    }
}
