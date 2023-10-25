using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.City;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Services
{
    public interface ICityService : IService
    {
        Task<List<CityDto>> ReadCityByDto(CityDto cityDto);
        Task<CityDto> ReadCityById(int id);
        Task<List<CityDto>> ReadCityByProvinceId(int id);
    }
}
