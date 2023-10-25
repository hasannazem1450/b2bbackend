using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Queries.BaseInfo.IndustrialPark;
using B2B.Application.Contracts.Services.BaseInfo.IndustrialPark;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.QueryHandlers.BaseInfo.IndustrialPark
{
    public class ReadIndustrialParkQueryHandler : IQueryHandler<ReadIndustrialParkQuery, ReadIndustrialParkQueryResponse>
    {
        private readonly IIndustrialParkService _industrialParkService;

        public ReadIndustrialParkQueryHandler(IIndustrialParkService industrialParkService)
        {
            _industrialParkService = industrialParkService;
        }

        public async Task<ReadIndustrialParkQueryResponse> Execute(ReadIndustrialParkQuery query, CancellationToken cancellationToken)
        {
            var industrialParkDto = await _industrialParkService.Read();

            var result = new ReadIndustrialParkQueryResponse()
            {
                List = industrialParkDto,
            };

            return result;
        }
    }
}
