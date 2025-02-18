using Bll.Interfaces;
using Dal.Dto;
using Dal.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        { _itemService = itemService; }

        [HttpPost("AddItem")]

        public async Task<ActionResult<int>> AddItem([FromBody] AddItemDto item)
        {
            try
            {
                int id = await _itemService.AddItemAsync(item);
                return Ok(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpPut("UpdateItem")]
        public async Task<ActionResult> UpdateItem([FromBody] ItemEntity item)
        {
            try
            {
                await _itemService.UpdateItemAsync(item);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpDelete("DeleteItem/{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            try
            {
                await _itemService.DeleteItemAsync(id);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpGet("GetAllItem")]
        public async Task<ActionResult<List<ItemDto>>> GetAllItem()
        {
            try
            {
                return await _itemService.GetAllItemAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpGet("GetItemByCategory/{id}")]
        public async Task<ActionResult<List<ItemDto>>> GetItemByCategory(int id)
        {
            try
            {
                return await _itemService.GetItemByCategoryIdAsync(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpGet("GetItemByItem/{id}")]
        public async Task<ActionResult<ItemDto>> GetItemByItem(int id)
        {
            try 
            {
                return await _itemService.GetItemByItemIdAsync(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
