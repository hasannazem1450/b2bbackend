using B2B.Application.Contracts.Queries.Event;
using B2B.Framework.Contracts.Common.Enums;
using B2B.Framework.Contracts.Markers;
using B2B.Utilities.Extensions;

namespace B2B.Application.QueryHandlers.Event;

public class ReadAttenderTypesQueryHandler : IQueryHandler<ReadAttenderTypesQuery, ReadAttenderTypesQueryResponse>
{
    public async Task<ReadAttenderTypesQueryResponse> Execute(ReadAttenderTypesQuery query,
        CancellationToken cancellationToken)
    {
        var smeTypes = Enum.GetValues<EventAttenderType>();
        
        var result = new ReadAttenderTypesQueryResponse
        {
            List = smeTypes.Select(s => new EventAttenderTypeDto
            {
                Value = (int)s,
                Name = s.GetDescription()
            }).ToList()
        };

        return result;
    }
}