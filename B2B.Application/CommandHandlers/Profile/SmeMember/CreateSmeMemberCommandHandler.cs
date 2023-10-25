using B2B.Application.Contracts.Commands.Profile.SmeMember;
using B2B.Application.Contracts.Repository.Profile;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.Profile.SmeMember
{
    public class CreateSmeMemberCommandHandler : CommandHandler<CreateSmeMemberCommand, CreateSmeMemberCommandResponse>
    {

        private readonly ISmeMemberRepository _smeMemberRepository;

        public CreateSmeMemberCommandHandler(ISmeMemberRepository smeMemberRepository)
        {
            _smeMemberRepository = smeMemberRepository;
        }

        public override async Task<CreateSmeMemberCommandResponse> Executor(CreateSmeMemberCommand command)
        {
            var smeMember = new Domain.Profile.SmeMember(command.Name, command.ProfilePhoto)
            {
                SmeProfileId = command.SmeProfileId,
                PositionId = command.PositionId,
            };

            await _smeMemberRepository.Create(smeMember);
            
            return new CreateSmeMemberCommandResponse();
        }
    }
}
