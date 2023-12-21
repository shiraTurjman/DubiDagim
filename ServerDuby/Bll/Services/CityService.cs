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
    public class CityService : ICtiyService

    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository) {
        _cityRepository = cityRepository;
        }

        public async Task<List<CityEntity>> GetAllCityAsync()
        {
           return await _cityRepository.GetAllCityAsync();

        }
    }
}
