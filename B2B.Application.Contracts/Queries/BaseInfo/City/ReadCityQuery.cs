using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.City;
using B2B.Application.Contracts.Queries.RoleManager;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.BaseInfo.City
{
    public class ReadCityQuery : Query
    {
        public int ProvinceId { get; set; }
    }

    public class ReadCityQueryResponse : QueryResponse
    {
        public ReadCityQueryResponse()
        {
            List = new List<CityDto>();
        }
        public List<CityDto> List { get; set; }
    }
}
