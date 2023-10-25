using B2B.Application.CommandHandlers.SmeProfile.Exceptions;
using B2B.Application.Contracts.Commands.Profile.SmeProfile;
using B2B.Application.Contracts.Repository.Profile;
using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common.Enums;

namespace B2B.Application.CommandHandlers.SmeProfile;

public class UpdateSmeProfileCommandHandler : CommandHandler<UpdateSmeProfileCommand, UpdateSmeProfileCommandResponse>
{
    private readonly ISmeProfileRepository _smeProfileRepository;
    private readonly ISmeRaterRepository _smeRaterRepository;

    public UpdateSmeProfileCommandHandler(ISmeProfileRepository smeProfileRepository,
        ISmeRaterRepository smeRaterRepository)
    {
        _smeProfileRepository = smeProfileRepository;
        _smeRaterRepository = smeRaterRepository;
    }

    public override async Task<UpdateSmeProfileCommandResponse> Executor(UpdateSmeProfileCommand command)
    {
        var smeProfile = await _smeProfileRepository.ReadById(command.Id);

        if (smeProfile == null)
            throw new SmeProfileNotExistException();

        smeProfile.Update(command.SmeName, command.NationalCode, command.BusinessCode, command.ManagerName,
            command.RegisterNumber, command.EconomyCode, command.PermitNo, command.ManagerPhoneNumber,
            command.ManagerEmail, command.AboutUs, command.TellNumber, command.ActivitySubject, command.SmeEmail,
            command.SmeWebsite, command.Address, command.CityId, command.SmeRankId, command.IndustrialParkId, command.Status, command.Logo,
            command.Headerpic, command.Postalcode, (SmeType) command.SmeType);

        await _smeProfileRepository.Update(smeProfile);

        return new UpdateSmeProfileCommandResponse();
    }
}