using Microsoft.EntityFrameworkCore;


namespace Dal.Entity
{
    public class ServerDbContext:DbContext
    {
        
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<CuttingShapeEntity> CuttingShapes { get; set; }
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<CuttingShapePerItemEntity> CuttingShapePerItem { get; set; }
        public DbSet<ImageDetailsEntity> ImageDetails { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<SaleEntity> Sales { get; set; }
        public DbSet<SameItemEntity> SameItems { get; set; }
        public DbSet<ItemInShoppingCartEntity> ItemInShoppingCarts { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public ServerDbContext(DbContextOptions<ServerDbContext> options) : base(options)
        { }
        //public ServerDbContext()
        //{

        //}

    }
}
