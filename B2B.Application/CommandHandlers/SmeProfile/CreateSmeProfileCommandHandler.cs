using B2B.Application.Contracts.Commands.Profile.SmeProfile;
using B2B.Application.Contracts.Repository.Profile;
using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common.Enums;

namespace B2B.Application.CommandHandlers.SmeProfile;

public class CreateSmeProfileCommandHandler : CommandHandler<CreateSmeProfileCommand, CreateSmeProfileCommandResponse>
{
    private readonly ISmeProfileRepository _smeProfileRepository;
    private readonly ISmeRaterRepository _smeRaterRepository;

    public CreateSmeProfileCommandHandler(ISmeProfileRepository smeProfileRepository,
        ISmeRaterRepository smeRaterRepository)
    {
        _smeProfileRepository = smeProfileRepository;
        _smeRaterRepository = smeRaterRepository;
    }

    public override async Task<CreateSmeProfileCommandResponse> Executor(CreateSmeProfileCommand command)
    {
        var smeProfile = new Domain.Profile.SmeProfile(command.SmeName, command.NationalCode, command.BusinessCode,
            command.ManagerName, command.RegisterNumber, command.EconomyCode, command.PermitNo,
            command.ManagerPhoneNumber, command.ManagerEmail, command.AboutUs, command.TellNumber,
            command.ActivitySubject, command.SmeEmail, command.SmeWebsite, command.Address, command.CityId, command.SmeRankId,
            command.IndustrialParkId, command.Status, command.Logo, command.Headerpic, command.Postalcode,
            (SmeType) command.SmeType);

        await _smeProfileRepository.Create(smeProfile);

        return new CreateSmeProfileCommandResponse
        {
            Id = smeProfile.Id
        };
    }
}