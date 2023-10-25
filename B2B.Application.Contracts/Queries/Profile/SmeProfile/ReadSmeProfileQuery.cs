using B2B.Application.Contracts.Commands.Profile.SmeProfile;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.Profile.SmeProfile;

public class ReadSmeProfileQuery : Query
{
    public int Id { get; set; }
}

public class ReadSmeProfileQueryResponse : QueryResponse
{
    public SmeProfileDto Dto { get; set; }
}