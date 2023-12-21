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
    public class ItemInShoppingCartService : IItemInShoppingCartService
    {
        private readonly IItemInShoppingCartRepository _itemInShoppingCart;

        public ItemInShoppingCartService(IItemInShoppingCartRepository itemInShoppingCart) {
            _itemInShoppingCart = itemInShoppingCart;        
        }

        public async Task AddItemToOrder(ItemInShoppingCartEntity item)
        {
            await _itemInShoppingCart.AddItemToOrder(item);
        }

        public async Task DeleteAllItemInOrder(int orderId)
        {
            await _itemInShoppingCart.DeleteAllItemInOrder(orderId);
        }

        public async Task DeleteItemFromOrder(int ItemInShoppingId)
        { 
           await _itemInShoppingCart.DeleteItemFromOrder(ItemInShoppingId);
        }

        public async Task<List<ItemInShoppingCartEntity>> GetItemInOrderByOrderId(int OrderId)
        {
           return await _itemInShoppingCart.GetItemInOrderByOrderId(OrderId);
        }

        public async Task UpdateItemInOrder(ItemInShoppingCartEntity item)
        {
            await _itemInShoppingCart.UpdateItemInOrder(item);
        }
    }

}
