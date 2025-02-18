using Dal.Dto;
using Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface IItemService
    {
        Task<int> AddItemAsync(AddItemDto item);
        Task UpdateItemAsync(ItemEntity item);
        Task<int> DeleteItemAsync(int itemId);

        Task<List<ItemDto>> GetAllItemAsync();
        Task<List<ItemDto>> GetItemByCategoryIdAsync(int categoryId);
        Task<ItemDto> GetItemByItemIdAsync(int itemId);
    }
}
