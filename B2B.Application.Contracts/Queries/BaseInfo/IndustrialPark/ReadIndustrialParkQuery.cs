using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.IndustrialPark;
using B2B.Application.Contracts.Commands.BaseInfo.Province;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.BaseInfo.IndustrialPark
{
    public class ReadIndustrialParkQuery : Query
    {

    }

    public class ReadIndustrialParkQueryResponse : QueryResponse
    {
        public ReadIndustrialParkQueryResponse()
        {
            List = new List<IndustrialParkDto>();
        }
        public List<IndustrialParkDto> List { get; set; }
    }
}
