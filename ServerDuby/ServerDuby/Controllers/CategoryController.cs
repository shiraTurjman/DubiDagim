using Bll.Interfaces;
using Dal.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategories")]
        public async Task <ActionResult<List<CategoryEntity>>> getAllCategories()
        {
            try 
            {
                return Ok(await _categoryService.GetAllCategoriesAsync());
            
             } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpGet("GetCategoryById/{id}")]
        public async Task<ActionResult<CategoryEntity>> getCategoryById(int id)
        {
            try
            {
                return Ok(await _categoryService.GetCategoryByIdAsync(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("AddCategory")]
        public async Task<ActionResult<int>> AddCategory([FromBody] CategoryEntity category)
        {
            try 
            {
                await _categoryService.AddCategoryAsync(category);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory([FromBody] CategoryEntity category)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(category);
                return Ok(true);
            }
            catch (Exception ex)
            { 
            throw new Exception(ex.Message);
            }
        }
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return Ok(true);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
