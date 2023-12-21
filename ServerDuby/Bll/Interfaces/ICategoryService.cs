using Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(CategoryEntity category);
        Task UpdateCategoryAsync(CategoryEntity category);
        Task DeleteCategoryAsync(int categoryId);
        Task<List<CategoryEntity>> GetAllCategoriesAsync();

        Task<string> GetCategoryNameById(int categoryId);
    }
}
