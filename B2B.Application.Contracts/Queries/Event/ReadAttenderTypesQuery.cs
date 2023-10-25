using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.Event;

public class ReadAttenderTypesQuery : Query
{
}

public class ReadAttenderTypesQueryResponse : QueryResponse
{
    public List<EventAttenderTypeDto> List { get; set; }
}