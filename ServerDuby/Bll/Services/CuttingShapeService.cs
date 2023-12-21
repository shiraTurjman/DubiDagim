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
    public class CuttingShapeService :ICuttingShapeService
    {
        private readonly ICuttingShapeRepository _cuttingShapeRepository;
        private readonly ICuttingShapePerItemRepository _cuttingShapePerItemRepository;
        public CuttingShapeService(ICuttingShapeRepository cuttingShapeRepository, ICuttingShapePerItemRepository cuttingShapePerItemRepository ) {
           _cuttingShapeRepository = cuttingShapeRepository;
            _cuttingShapePerItemRepository = cuttingShapePerItemRepository;
        }

        public async Task AddCuttingShapeAsync(CuttingShapeEntity cuttingShape)
        {
            await _cuttingShapeRepository.AddCuttingShapeAsync(cuttingShape);
        }

        public async Task DeleteCuttingShapeAsync(int cuttingShapeId)
        {
            await _cuttingShapePerItemRepository.DeleteCuttingShapePerItemByCuttingShapeIdAsync(cuttingShapeId);
            await _cuttingShapeRepository.DeleteCuttingShapeAsync(cuttingShapeId);
        }

        public async Task<List<CuttingShapeEntity>> GetAllCuttingShapeAsync()
        {
            return await _cuttingShapeRepository.GetAllCuttingShapeAsync();
        }

        public async Task<CuttingShapeEntity> GetCuttingShapeByIdAsync(int cuttingShapeId)
        {
            return await _cuttingShapeRepository.GetCuttingShapeByIdAsync(cuttingShapeId);
        }

        public async Task UpdateCuttingShapeAsync(CuttingShapeEntity cuttingShape)
        {
            await _cuttingShapeRepository.UpdateCuttingShapeAsync(cuttingShape);
        }
    }
}
