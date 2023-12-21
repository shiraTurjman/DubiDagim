using Bll.Interfaces;
using Dal.Dto;
using Dal.Entity;
using Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Services
{
    public class SameItemService :ISameItemService
    {
        private readonly ISameItemRepository _sameItemRepository;
        private readonly IItemService _itemService;
        public SameItemService(ISameItemRepository sameItemRepository,IItemService itemService) {
        _sameItemRepository = sameItemRepository;
            _itemService = itemService; 
        }

        public async Task AddSameItemAsync(SameItemEntity sameItem)
        {
            await _sameItemRepository.AddSameItemAsync(sameItem);   
        }

        public async Task DeleteSameItemByItemIdAsync(int itemId)
        {
            await _sameItemRepository.DeleteSameItemByItemIdAsync(itemId);
        }

        public async Task DeleteSameItemBySameItemIdAsync(int sameItemId)
        {
            await _sameItemRepository.DeleteSameItemBySameItemIdAsync(sameItemId);
        }

        public async Task<List<ItemDto>> GetSameItemByItemId(int itemId)
        {
            List<ItemDto> items = new List<ItemDto>();
            
            var sameItems = await _sameItemRepository.GetSameItemByItemId(itemId);
            foreach (var item in sameItems)
            {

                int itemToGet = (int)(item.ItemAId != itemId ? item.ItemAId : item.ItemBId);
                
                 var itemToAdd=await _itemService.GetItemByItemIdAsync(itemToGet); 
                  items.Add(itemToAdd);
            }
            return items;
        }

        public async Task<SameItemEntity> GetSameItemByTwoItemId(int itemAID, int ItemBId)
        {
            return await _sameItemRepository.GetSameItemByTwoItemId(itemAID, ItemBId); 
        }
    }
}
