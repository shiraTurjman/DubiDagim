using Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface ICuttingShapeService
    {
        Task AddCuttingShapeAsync(CuttingShapeEntity cuttingShape);
        Task DeleteCuttingShapeAsync(int cuttingShapeId);
        Task UpdateCuttingShapeAsync(CuttingShapeEntity cuttingShape);
        Task<List<CuttingShapeEntity>> GetAllCuttingShapeAsync();
        Task<CuttingShapeEntity> GetCuttingShapeByIdAsync(int cuttingShapeId);
    }
}
