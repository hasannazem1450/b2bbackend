using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.Country;
using B2B.Domain.BaseInfo;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.BaseInfo
{
    public interface ICountryRepository :IRepository
    {
        Task<List<Country>> ReadCountryByDto(CountryDto countryDto);
        Task<Country> ReadCountryById(int id);
    }
}
