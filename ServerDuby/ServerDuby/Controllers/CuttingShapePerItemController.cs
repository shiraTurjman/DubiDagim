using Bll.Interfaces;
using Dal.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuttingShapePerItemController : ControllerBase

    {
        private readonly ICuttingShapePerItemService _cuttingShapePerItemService;

        public CuttingShapePerItemController(ICuttingShapePerItemService cuttingShapePerItemService)
        {
            _cuttingShapePerItemService = cuttingShapePerItemService;
        }

        [HttpPost("AddCuttingShapePetItem")]
        public async Task<ActionResult> AddCuttingShapePerItem([FromBody] CuttingShapePerItemEntity cuttingShapePerItem)
        {
            try 
            {
                await _cuttingShapePerItemService.AddCuttingShapePerItemAsync(cuttingShapePerItem);
                return Ok(true);
                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteCuttingShapePerItemByItemIdAndCuttinId/{itemId}/{cuttingShapeId}")]

        public async Task<ActionResult> DeleteCuttingShapePerItemByItemIdAndCuttinId(int itemId, int cuttingShapeId)
        {
            try 
            {
                await _cuttingShapePerItemService.DeleteCuttingShapePerItemByItemIdAndCuttinIdAsync(itemId, cuttingShapeId);
                return Ok(true);
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteCuttingShapePerItemByItemId/{itemId}")]
        public async Task<ActionResult> DeleteCuttingShapePerItemByItemId(int itemId)
        {
            try {
                await _cuttingShapePerItemService.DeleteCuttingShapePerItemByItemIdAsync(itemId);
                return Ok(true);

            }
            catch (Exception ex) { 
            throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteCuttingShapePerItemByCuttingShapeId/{cuttingShapeId}")]

        public async Task<ActionResult> DeleteCuttingShapePerItemByCuttingShapeId(int cuttingShapeId)
        {
            try
            {
                await _cuttingShapePerItemService.DeleteCuttingShapePerItemByCuttingShapeIdAsync(cuttingShapeId);
                return Ok(true);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpGet("GetByItemId/{itemId}")]

        public async Task<ActionResult<List<CuttingShapeEntity>>> GetCuttingShapeByItemId(int itemId)
        {
            try
            {
                return await _cuttingShapePerItemService.GetAllCuttingShapePerItemByItemIdAsync(itemId);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
