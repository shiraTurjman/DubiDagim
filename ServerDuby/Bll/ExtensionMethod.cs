using Bll.Interfaces;
using Bll.Services;
using Dal.Entity;
using Dal.Interfaces;
using Dal.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public static class ExtensionMethod
    {
        public static void InitDI(IServiceCollection service, string connectionString)
        {
            service.AddPooledDbContextFactory<ServerDbContext>(item => item.UseSqlServer(connectionString));

            //dependency injection 
            //repository-dal
            service.AddScoped<ICategoriesRepository, CategoryRepository>();
            service.AddScoped<ICityRepository, CityRepository>();
            service.AddScoped<ICuttingShapePerItemRepository, CuttingShapePerItemRepository>();
            service.AddScoped<ICuttingShapeRepository, CuttingShapeRepository>();
            service.AddScoped<IImageRepository, ImageRepository>();
            service.AddScoped<IItemInShoppingCartRepository, ItemInShoppingCartRepository>();
            service.AddScoped<IItemRepository, ItemRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<ISaleRepository, SaleRepository>();
            service.AddScoped<ISameItemRepository, SameItemRepository>();
            service.AddScoped<IUserRepository, UserRepository>();

            //service-bll
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<ICityService, CityService>();
            service.AddScoped<ICuttingShapePerItemService, CuttingShapePerItemService>();
            service.AddScoped<ICuttingShapeService, CuttingShapeService>();
            service.AddScoped<IImageService, ImageSarvice>();
            service.AddScoped<IItemInShoppingCartService, ItemInShoppingCartService>();
            service.AddScoped<IItemService, ItemService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<ISaleService, SaleService>();
            service.AddScoped<ISameItemService, SameItemService>();
            service.AddScoped<IUserService, UserService>();


        }
    }
}
