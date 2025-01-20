using Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface ICityService
    {
        Task<List<CityEntity>> GetAllCityAsync();

        Task AddCityAsync(CityEntity city);
    }
}
