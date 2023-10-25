using B2B.Application.Contracts.Commands.Event;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.Event;

public class ReadEventInfoQuery : Query
{
    public int Id { get; set; }
}

public class ReadEventInfoQueryResponse : QueryResponse
{
    public EventInfoDto Data { get; set; }
}