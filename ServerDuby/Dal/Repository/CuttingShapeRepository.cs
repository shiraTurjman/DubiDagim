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
    
    public class CuttingShapeRepository : ICuttingShapeRepository
    {
        private readonly IDbContextFactory<ServerDbContext> _factory;
        public CuttingShapeRepository(IDbContextFactory<ServerDbContext> factory) { 
         _factory = factory;    

        }

       public async Task AddCuttingShapeAsync(CuttingShapeEntity cuttingShape)
        {
            using var context = _factory.CreateDbContext();
            await context.CuttingShapes.AddAsync(cuttingShape);
            await context.SaveChangesAsync();
            
            
        }

        public async Task DeleteCuttingShapeAsync(int cuttingShapeId)
        {
            using var context = _factory.CreateDbContext();
            CuttingShapeEntity cuttingToDelete = await context.CuttingShapes.FindAsync(cuttingShapeId);
            if (cuttingToDelete != null)
            {
                context.CuttingShapes.Remove(cuttingToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Could not delete cutting shape");
            }
        }

        public async Task<List<CuttingShapeEntity>> GetAllCuttingShapeAsync()
        {
            using var context = _factory.CreateDbContext();
            var cuttingShape = await context.CuttingShapes.ToListAsync();
            if (cuttingShape != null)
            { return cuttingShape; }
            else
            {
                throw new Exception("could not get cutting shape");
            }

        }

        public async Task<CuttingShapeEntity> GetCuttingShapeByIdAsync(int cuttingShapeId)
        {
            using var context = _factory.CreateDbContext();
            CuttingShapeEntity cuttingShape = await context.CuttingShapes.FindAsync(cuttingShapeId);
            if (cuttingShape != null)
            { return cuttingShape; }
            else
            { throw new Exception("could not get cutting shape"); }
        }

        public async Task UpdateCuttingShapeAsync(CuttingShapeEntity cuttingShape)
        {
            using var context = _factory.CreateDbContext();
            var cuttingToUpdate = context.CuttingShapes.FirstOrDefault(c=>c.CuttingShapeId==cuttingShape.CuttingShapeId);
            if (cuttingToUpdate != null)
            {
                cuttingToUpdate.ShapeName = cuttingShape.ShapeName;
                cuttingToUpdate.Details = cuttingShape.Details;
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("the cutting shape you are try to update doesn't exist.");
            }
        }
    }
}
