using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Queries.News;
using B2B.Application.Contracts.Repository.News;
using B2B.Application.Contracts.Services.News;
using B2B.Application.Contracts.Services.Profile.Member;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.QueryHandlers.News
{
    public class ReadNewsQueryHandler : IQueryHandler<ReadSmeProfileNewsQuery, ReadNewsQueryResponse>
    {
        private readonly INewsService _newsService;


        public ReadNewsQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<ReadNewsQueryResponse> Execute(ReadSmeProfileNewsQuery query,
            CancellationToken cancellationToken)
        {
            var newsDtos = await _newsService.ReadNewsBySmeProfileId(query.SmeProfileId);

            var result = new ReadNewsQueryResponse()
            {
                List = newsDtos,
            };

            return result;
        }
    }
}
