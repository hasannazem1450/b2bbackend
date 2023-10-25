using B2B.Application.Contracts.Commands.Profile.SmeProfile;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.Profile.SmeProfile;

public class ReadLatestSmeProfilesQuery : Query
{
}

public class ReadLatestSmeProfilesQueryResponse : QueryResponse
{
    public List<SmeProfileDto> Profiles { get; set; }
}