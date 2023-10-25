using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.Country;
using B2B.Application.Contracts.Repository.BaseInfo;
using B2B.CommandDB;
using B2B.Domain.BaseInfo;

namespace B2B.CommandDb.Repository.BaseInfo
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        public CountryRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<Country>> ReadCountryByDto(CountryDto countryDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Country> ReadCountryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
