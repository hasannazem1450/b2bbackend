using B2B.Application.Contracts.Queries.Profile.SmeProfile;
using B2B.Application.Contracts.Repository.Profile;
using B2B.Application.Contracts.Services.Profile;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.QueryHandlers.Profile.SmeProfile;

public class ReadSmeProfileQueryHandler : IQueryHandler<ReadSmeProfileQuery, ReadSmeProfileQueryResponse>
{
    private readonly ISmeProfileRepository _smeProfileRepository;
    private readonly ISmeProfileService _smeProfileService;

    public ReadSmeProfileQueryHandler(ISmeProfileRepository smeProfileRepository, ISmeProfileService smeProfileService)
    {
        _smeProfileRepository = smeProfileRepository;
        _smeProfileService = smeProfileService;
    }

    public async Task<ReadSmeProfileQueryResponse> Execute(ReadSmeProfileQuery query,
        CancellationToken cancellationToken)
    {
        var smeProfile = await _smeProfileRepository.ReadById(query.Id);

        var result = new ReadSmeProfileQueryResponse
        {
            Dto = await _smeProfileService.ConvertToDto(smeProfile)
        };

        return result;
    }
}