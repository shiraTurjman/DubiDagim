using Bll.Interfaces;
using Bll.Services;
using Dal.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService) { _cityService = cityService; }

        [HttpGet("GetCities")]
        public async Task<ActionResult<List<CityEntity>>> getAllCities()
        {
            try
            {
                return Ok(await _cityService.GetAllCityAsync());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost("AddCity")]
        public async Task<ActionResult<int>> AddCity([FromBody] CityEntity city)
        {
            try
            {
                await _cityService.AddCityAsync(city);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
