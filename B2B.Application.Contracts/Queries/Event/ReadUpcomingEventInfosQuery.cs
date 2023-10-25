using B2B.Application.Contracts.Commands.Event;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.Event;

public class ReadUpcomingEventInfosQuery : Query
{
}

public class ReadUpcomingEventInfosQueryResponse : QueryResponse
{
    public List<EventInfoDto> List { get; set; }
}