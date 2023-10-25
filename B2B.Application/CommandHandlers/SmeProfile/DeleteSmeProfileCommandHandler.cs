using B2B.Application.CommandHandlers.SmeProfile.Exceptions;
using B2B.Application.Contracts.Commands.Profile.SmeProfile;
using B2B.Application.Contracts.Repository.Profile;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.SmeProfile;

public class DeleteSmeProfileCommandHandler : CommandHandler<DeleteSmeProfileCommand, DeleteSmeProfileCommandResponse>
{
    private readonly ISmeProfileRepository _smeProfileRepository;

    public DeleteSmeProfileCommandHandler(ISmeProfileRepository smeProfileRepository)
    {
        _smeProfileRepository = smeProfileRepository;
    }

    public override async Task<DeleteSmeProfileCommandResponse> Executor(DeleteSmeProfileCommand command)
    {
        var smeProfile = await _smeProfileRepository.ReadById(command.Id);

        if (smeProfile == null)
            throw new SmeProfileNotExistException();

        await _smeProfileRepository.Delete(smeProfile.Id);

        return new DeleteSmeProfileCommandResponse();
    }


}