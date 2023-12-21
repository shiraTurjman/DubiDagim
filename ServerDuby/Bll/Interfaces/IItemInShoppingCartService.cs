using Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface IItemInShoppingCartService
    {
        Task AddItemToOrder(ItemInShoppingCartEntity item);
        Task DeleteItemFromOrder(int ItemInShoppingId);

        Task DeleteAllItemInOrder(int orderId);

        Task UpdateItemInOrder(ItemInShoppingCartEntity item);

        Task<List<ItemInShoppingCartEntity>> GetItemInOrderByOrderId(int OrderId);
    }
}
