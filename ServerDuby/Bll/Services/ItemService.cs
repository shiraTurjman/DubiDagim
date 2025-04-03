using Bll.Interfaces;
using Dal.Dto;
using Dal.Entity;
using Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bll.Services
{
    public class ItemService :IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;
        private readonly ICuttingShapePerItemService _cuttingShapePerItemService;
        public ItemService(IItemRepository itemRepository, IImageService imageService,ICategoryService categoryService,ICuttingShapePerItemService cuttingShapePerItemService) { 
        _itemRepository = itemRepository;
            _imageService = imageService;
            _categoryService = categoryService;
            _cuttingShapePerItemService = cuttingShapePerItemService;
            
        }

        public async Task<int> AddItemAsync(AddItemDto item)
        {
            var itemToAdd = new ItemEntity 
            {
                ItemEnName = item.ItemEnName,
                ItemHeName = item.ItemHeName,
                Price = item.Price,
                CategoryId = item.CategoryId,
                Details = item.Details,
                AverageSize = item.AverageSize,
            };
           return await _itemRepository.AddItemAsync(itemToAdd);
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
                //List<byte[]> images = new List<byte[]>();
                byte[] images = await _imageService.GetFirstImageByItemIdAsync(item.ItemId);
                var categoryName = await _categoryService.GetCategoryNameById(item.CategoryId);
                result.Add(new ItemDto()
                {
                    ItemId = item.ItemId,
                    ItemEnName =item.ItemEnName,
                    ItemHeName =item.ItemHeName,
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
                //List<byte[]> images = new List<byte[]>();
                //images = await _imageService.GetImageByItemIdAsync(item.ItemId);
                byte[] image = await _imageService.GetFirstImageByItemIdAsync(item.ItemId);
                List<CuttingShapeEntity> cutting = await _cuttingShapePerItemService.GetAllCuttingShapePerItemByItemIdAsync(item.ItemId);
                List<CuttingShapeDto> cuttingShapeList = new List<CuttingShapeDto>();

                if (cutting != null) { 

                    foreach (var cuttingShape in cutting) 
                    {
                        cuttingShapeList.Add(new CuttingShapeDto()
                        {
                            Id = cuttingShape.CuttingShapeId,
                            EnName = cuttingShape.ShapeEnName,
                            HeName = cuttingShape.ShapeHeName,
                        }); ;
                    
                     }
                }
                
                result.Add(new ItemDto()
                {
                    ItemId = item.ItemId,
                    ItemEnName = item.ItemEnName,
                    ItemHeName = item.ItemHeName,
                    Price = item.Price,
                    CategoryId = item.CategoryId,
                    CategoryName = categoryName,
                    Details = item.Details,
                    AverageSize = item.AverageSize,
                    Images = image,
                    cuttingShapes = cuttingShapeList,

                }); ;
            }
            return result;

        }

        public async Task<ItemDto> GetItemByItemIdAsync(int itemId)
        {
            ItemDto result = new ItemDto();
            //List<byte[]> images = new List<byte[]>();
            byte[] images = await _imageService.GetFirstImageByItemIdAsync(itemId);
            var itemTemp= await _itemRepository.GetItemByItemIdAsync(itemId);
            result.ItemId = itemId;
            result.ItemEnName = itemTemp.ItemEnName;
            result.ItemHeName = itemTemp.ItemHeName;
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
