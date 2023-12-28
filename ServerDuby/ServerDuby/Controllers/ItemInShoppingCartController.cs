using Bll.Interfaces;
using Dal.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemInShoppingCartController : ControllerBase
    {
        private readonly IItemInShoppingCartService _itemInShoppingCartService;
        public ItemInShoppingCartController(IItemInShoppingCartService itemInShoppingCartService)
        {
            _itemInShoppingCartService = itemInShoppingCartService;
        }

        [HttpPost("AddItemToOrder")]
        public async Task<ActionResult> AddItemToOrder([FromBody] ItemInShoppingCartEntity item)
        {
            try
            {
                await _itemInShoppingCartService.AddItemToOrder(item);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpDelete("DeleteItemFromOrder/{id}")]
        public async Task<ActionResult> DeleteItemFromOrder(int id)
        {
            try
            {
                await _itemInShoppingCartService.DeleteItemFromOrder(id);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpDelete("DeleteAllItemInOrder/orderId")]
        public async Task<ActionResult> DeleteAllItemInOrder(int orderId)
        {
            try
            {
                await _itemInShoppingCartService.DeleteAllItemInOrder(orderId);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpPut("UpdateItemInOrder")]
        public async Task<ActionResult> UpdateItemInOrder([FromBody] ItemInShoppingCartEntity item)
        {
            try
            {
                await _itemInShoppingCartService.UpdateItemInOrder(item);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpGet("GetItemsOrder/{id}")]

        public async Task<ActionResult<List<ItemInShoppingCartEntity>>> GetItemsOrder(int orderId)
        {
            try 
            {
                return await _itemInShoppingCartService.GetItemInOrderByOrderId(orderId);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }



    }
}
