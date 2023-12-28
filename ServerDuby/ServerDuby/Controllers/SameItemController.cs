using Bll.Interfaces;
using Dal.Dto;
using Dal.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SameItemController : ControllerBase
    {
       private readonly ISameItemService _sameItemService;

        public SameItemController(ISameItemService sameItemService)
        {
            _sameItemService = sameItemService;
        }

        [HttpPost("AddSameItem")]
        public async Task<ActionResult> AddSameItem([FromBody] SameItemEntity sameItem)
        {
            try
            {
                await _sameItemService.AddSameItemAsync(sameItem);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteBySameItem/{id}")]
        public async Task<ActionResult> DeleteBySameItem(int id)
        {
            try
            {
                await _sameItemService.DeleteSameItemBySameItemIdAsync(id);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpDelete("DeleteByItem/{id}")]
        public async Task<ActionResult> DeleteByItem(int id)
        {
            try
            {
                await _sameItemService.DeleteSameItemByItemIdAsync(id);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpGet("GetSameItemByItem/{id}")]
        public async Task<ActionResult<List<ItemDto>>> GetSameItemByItem(int id)
        {
            try
            {
                return await _sameItemService.GetSameItemByItemId(id);
            }

             catch (Exception ex) { throw new Exception(ex.Message) ; }
        }
        [HttpGet("GetByTwoItem/{aId}/{bId}")]
        public async Task<ActionResult<SameItemEntity>> GetByTwoItem(int aId, int bId)
        {
            try
            {
                return await _sameItemService.GetSameItemByTwoItemId(aId, bId);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


    }
}
