using Dal.Entity;
using Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class CategoryRepository : ICategoriesRepository
    {
        private readonly IDbContextFactory<ServerDbContext> _factory;
        public CategoryRepository(IDbContextFactory<ServerDbContext> factory)
        {
            _factory = factory;
        }
        public async Task AddCategoryAsync(CategoryEntity category)
        {
            using var context = _factory.CreateDbContext();
            await context.AddAsync(category);
            await context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {

            using var context = _factory.CreateDbContext();
            var category = context.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();
            if (category != null)
            {
                context.Remove(category);
                await context.SaveChangesAsync();
                return;
            }
            else
            {
                throw new Exception("Couldn't delete.");
            }
        }

       public async Task<List<CategoryEntity>> GetAllCategoriesAsync()
        {

            using var context = _factory.CreateDbContext();
            var list = await context.Categories.ToListAsync();
            if (list.Count >= 0)
                return list;
            else
                throw new Exception("No categories exist for the given id");

        }

        public async Task<CategoryEntity> GetCategoryByIdAsync(int id)
        {
            using var context = _factory.CreateDbContext();
            var category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
                return category;
            else
                throw new Exception("category not found");

        }
       public async Task UpdateCategoryAsync(CategoryEntity category)
        {
            using var context = _factory.CreateDbContext();
            var categoryToUpdate = context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (categoryToUpdate != null)
            {//לעשות המרה לבד כדי לא לאבד מצביע 
                categoryToUpdate.CategoryId = category.CategoryId;
                categoryToUpdate.CategoryEnName = category.CategoryEnName;
                categoryToUpdate.CategoryHeName = category.CategoryHeName;
                categoryToUpdate.Details = category.Details;
                categoryToUpdate.Icon = category.Icon;
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("The category you are trying to update doesn't exist.");
            }
        }

        public async Task<string> GetCategoryNameById(int categoryId)
        {
            using var context = _factory.CreateDbContext();
            var category = await context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
            if (category != null)
                return category.CategoryEnName +' '+ category.CategoryHeName;
            else
                throw new Exception("this category not found");
        }
    }
}
