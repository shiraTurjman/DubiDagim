using Bll.Interfaces;
using Dal.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuttingShapeController : ControllerBase
    {
        private readonly ICuttingShapeService _cuttingShapeService;

        public CuttingShapeController(ICuttingShapeService cuttingShapeService)
        {
            _cuttingShapeService = cuttingShapeService;
        }

        [HttpPost("AddCuttingShape")]
        public async Task<ActionResult> AddCuttingShape([FromBody] CuttingShapeEntity cuttingShape)
        {
            try 
            {
                await _cuttingShapeService.AddCuttingShapeAsync(cuttingShape);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpDelete("DeleteCuttingShape/{id}")]
        public async Task<ActionResult> DeleteCuttingShape(int cuttingShapeId)
        {
            try 
            {
                await _cuttingShapeService.DeleteCuttingShapeAsync(cuttingShapeId);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpPut("UpdateCuttingShape")]

        public async Task<ActionResult> UpdateCuttingShape([FromBody] CuttingShapeEntity cuttingShape)
        {
            try 
            {
                await _cuttingShapeService.UpdateCuttingShapeAsync(cuttingShape);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpGet("GetAllCuttingShape")]
        public async Task<ActionResult<List<CuttingShapeEntity>>> GetAllCuttingShape()
        {
            try
            {
                return await _cuttingShapeService.GetAllCuttingShapeAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpGet("GetCuttingShapeById/{id}")]
        public async Task<ActionResult<CuttingShapeEntity>> GetCuttingShapeById(int id) 
        {
            try
            {
                return await _cuttingShapeService.GetCuttingShapeByIdAsync(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }




    }
}
