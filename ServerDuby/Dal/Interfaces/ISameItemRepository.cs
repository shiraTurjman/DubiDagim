using Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface ISameItemRepository
    {
        Task AddSameItemAsync(SameItemEntity sameItem);
        Task DeleteSameItemBySameItemIdAsync(int sameItemId);
        Task DeleteSameItemByItemIdAsync(int itemId);

        Task<List<SameItemEntity>> GetSameItemByItemId(int itemId);

        Task<SameItemEntity> GetSameItemByTwoItemId(int itemAID,int ItemBId);
    }
}
