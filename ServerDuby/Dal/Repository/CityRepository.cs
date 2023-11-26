using Dal.Entity;
using Dal.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class CityRepository : ICityRepository
    {

        private readonly IDbContextFactory<ServerDbContext> _factory;
        public CityRepository(IDbContextFactory<ServerDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<List<CityEntity>> GetAllCityAsync()
        {
            using var context = _factory.CreateDbContext();
            var list = await context.Cities.ToListAsync();
            if (list.Count > 0)
                return list;
            else
                throw new Exception("No cities exist for the given id");
        }
    }
}
