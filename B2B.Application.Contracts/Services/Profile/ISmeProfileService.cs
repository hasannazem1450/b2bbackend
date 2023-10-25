using B2B.Application.Contracts.Commands.Profile.SmeProfile;
using B2B.Domain.Profile;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Services.Profile;

public interface ISmeProfileService : IService
{
    Task<List<SmeProfileDto>> ConvertToDto(List<SmeProfile> smeProfiles);
    Task<SmeProfileDto> ConvertToDto(SmeProfile smeProfile);

    Task<List<PreSmeProfileDto>> ConvertToPreDto(List<SmeProfile> smeProfiles);
    Task<PreSmeProfileDto> ConvertToPreDto(SmeProfile smeProfile);
}