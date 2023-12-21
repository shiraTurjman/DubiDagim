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
    public class ItemService :IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;
        public ItemService(IItemRepository itemRepository, IImageService imageService,ICategoryService categoryService) { 
        _itemRepository = itemRepository;
            _imageService = imageService;
            _categoryService = categoryService;
        }

        public async Task<int> AddItemAsync(ItemEntity item)
        {
           return await _itemRepository.AddItemAsync(item);
        }

        public async Task<int> DeleteItemAsync(int itemId)
        {
            await _imageService.DeleteImageByItemIdAsync(itemId);
            return await _itemRepository.DeleteItemAsync(itemId);

        }

        public async Task<List<ItemDto>> GetAllItemAsync()
        {
            List<ItemDto> result = new List<ItemDto>();
            var itemTemp = await _itemRepository.GetAllItemAsync();
            foreach ( var item in itemTemp ) 
            {
                List<byte[]> images = new List<byte[]>();
                images = await _imageService.GetImageByItemIdAsync(item.ItemId);
                var categoryName = await _categoryService.GetCategoryNameById(item.CategoryId);
                result.Add(new ItemDto()
                {
                    ItemId = item.ItemId,
                    ItemName =item.ItemName,
                    Price = item.Price,
                    CategoryId = item.CategoryId,
                    CategoryName = categoryName,
                    Details = item.Details,
                    AverageSize = item.AverageSize,
                    Images = images 
                    
                }); ;

            }
            return result;
        }

        public async Task<List<ItemDto>> GetItemByCategoryIdAsync(int categoryId)
        {
            List<ItemDto> result = new List<ItemDto>();
            var itemTemp = await _itemRepository.GetItemByCategoryIdAsync(categoryId);

            var categoryName = await _categoryService.GetCategoryNameById(categoryId);
            foreach ( var item in itemTemp )
            {
                List<byte[]> images = new List<byte[]>();
                images = await _imageService.GetImageByItemIdAsync(item.ItemId);
                result.Add(new ItemDto()
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    Price = item.Price,
                    CategoryId = item.CategoryId,
                    CategoryName = categoryName,
                    Details = item.Details,
                    AverageSize = item.AverageSize,
                    Images = images

                }); ;
            }
            return result;

        }

        public async Task<ItemDto> GetItemByItemIdAsync(int itemId)
        {
            ItemDto result = new ItemDto();
            List<byte[]> images = new List<byte[]>();
            images = await _imageService.GetImageByItemIdAsync(itemId);
            var itemTemp= await _itemRepository.GetItemByItemIdAsync(itemId);
            result.ItemId = itemId;
            result.ItemName = itemTemp.ItemName;
            result.Price = itemTemp.Price;
            result.CategoryId = itemTemp.CategoryId;
            result.CategoryName = await _categoryService.GetCategoryNameById(itemTemp.CategoryId);
            result.Details = itemTemp.Details;  
            result.AverageSize = itemTemp.AverageSize;
            result.Images = images;
            return result;
        }

        public async Task UpdateItemAsync(ItemEntity item)
        {
           await _itemRepository.UpdateItemAsync(item);
        }
    }
}
