using B2B.Application.Contracts.Queries.Profile.SmeProfile;
using B2B.Application.Contracts.Repository.Profile;
using B2B.Application.Contracts.Services.Profile;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.QueryHandlers.Profile.SmeProfile;

public class
    ReadLatestSmeProfilesQueryHandler : IQueryHandler<ReadLatestSmeProfilesQuery, ReadLatestSmeProfilesQueryResponse>
{
    private readonly ISmeProfileRepository _smeProfileRepository;
    private readonly ISmeProfileService _smeProfileService;

    public ReadLatestSmeProfilesQueryHandler(ISmeProfileRepository smeProfileRepository,
        ISmeProfileService smeProfileService)
    {
        _smeProfileRepository = smeProfileRepository;
        _smeProfileService = smeProfileService;
    }


    public async Task<ReadLatestSmeProfilesQueryResponse> Execute(ReadLatestSmeProfilesQuery query,
        CancellationToken cancellationToken)
    {
        var lastRecords = await _smeProfileRepository.ReadLast(10);

        var result = new ReadLatestSmeProfilesQueryResponse
        {
            Profiles = await _smeProfileService.ConvertToDto(lastRecords)
        };

        return result;
    }
}