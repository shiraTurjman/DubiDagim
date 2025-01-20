using Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface ICityRepository
    {
        Task<List<CityEntity>> GetAllCityAsync();

        Task AddCityAsync(CityEntity city);
    }
}
