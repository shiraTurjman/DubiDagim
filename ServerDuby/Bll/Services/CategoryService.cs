using Bll.Interfaces;
using Dal.Entity;
using Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Services
{
    public class CategoryService :ICategoryService
    {
        private readonly ICategoriesRepository _ICategoryRepository;

        public CategoryService(ICategoriesRepository categoriesRepository)
        {
             _ICategoryRepository = categoriesRepository;
        }

        public async Task AddCategoryAsync(CategoryEntity category)
        {
            await _ICategoryRepository.AddCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _ICategoryRepository.DeleteCategoryAsync(categoryId);
        }

        public async Task<List<CategoryEntity>> GetAllCategoriesAsync()
        {
            return await _ICategoryRepository.GetAllCategoriesAsync();
        }

        public async Task<CategoryEntity> GetCategoryByIdAsync(int id)
        { 
            return await _ICategoryRepository.GetCategoryByIdAsync(id);
        }
        public  async Task UpdateCategoryAsync(CategoryEntity category)
        {
            await _ICategoryRepository.UpdateCategoryAsync(category);
        }

        public async Task<string> GetCategoryNameById(int categoryId)
        {
            return await  _ICategoryRepository.GetCategoryNameById(categoryId);
        }
    }
}
