using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Queries.Profile.Member;
using B2B.Application.Contracts.Queries.RoleManager;
using B2B.Application.Contracts.Services.Profile.Member;
using B2B.Framework.Contracts.Markers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace B2B.Application.QueryHandlers.Profile.Member
{
    public class
        ReadPositionQueryHandler : IQueryHandler<ReadPositionQuery, ReadPositionQueryResponse>
    {
        private readonly IPositionService _positionService;

        public ReadPositionQueryHandler(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public async Task<ReadPositionQueryResponse> Execute(ReadPositionQuery query,
            CancellationToken cancellationToken)
        {
            var position = await _positionService.Read();

            var result = new ReadPositionQueryResponse()
            {
                List = position
            };

            return result;
        }
    }
}
