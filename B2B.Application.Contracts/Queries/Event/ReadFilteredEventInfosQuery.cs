using B2B.Application.Contracts.Commands.Event;
using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common.Enums;

namespace B2B.Application.Contracts.Queries.Event;

public class ReadFilteredEventInfosQuery : Query
{
    public string? Name { get; set; }
    public int? ProvinceId { get; set; }
    public int[]? States { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}

public class ReadFilteredEventInfosQueryResponse : QueryResponse
{
    public List<EventInfoDto> List { get; set; }
}