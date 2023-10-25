using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.City;
using B2B.Domain.BaseInfo;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.BaseInfo
{
    public interface ICityRepository : IRepository
    {
        Task<List<City>> ReadCityByDto(CityDto cityDto);
        Task<City> ReadCityById(int id);
        Task<List<City>> ReadCityByProvinceId(int id);

        Task Delete(int id);

        Task Update(Domain.BaseInfo.City city);

        Task Create(Domain.BaseInfo.City city);
    }
}
