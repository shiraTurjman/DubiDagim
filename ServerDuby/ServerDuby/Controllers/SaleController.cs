using Bll.Interfaces;
using Dal.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost("AddSale")]
        public async Task<ActionResult> AddSale([FromBody] SaleEntity sale)
        {
            try
            {
                await _saleService.AddSaleAsync(sale);
                return Ok(true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteSale/{id}")]
        public async Task<ActionResult> DeleteSale(int id)
        {
            try
            {
                await _saleService.DeleteSaleAsync(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("DeleteSaleByItem/{itemId}")]
        public async Task<ActionResult> DeleteSaleByItem(int itemId)
        {
            try
            {
                await _saleService.DeleteSaleByItemIdAsync(itemId);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpPut("UpdateSale")]
        public async Task<ActionResult> UpdateSale([FromBody] SaleEntity sale)
        {
            try
            {
                await _saleService.UpdateSaleAsync(sale);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpGet("GetAllSale")]

        public async Task<ActionResult<List<SaleEntity>>> GetAllSale() 
        {
            try
            {
                return await _saleService.GetAllSaleAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpGet("GetSaleByItem/{id}")]
        public async Task<ActionResult<List<SaleEntity>>> GetSaleByItem(int id)
        {
            try
            {
                return await _saleService.GetSaleByItemIdAsync(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
