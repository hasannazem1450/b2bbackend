using B2B.Application.Contracts.Commands.Profile.UserProfile;
using B2B.Application.Contracts.Repository.Profile;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.Profile.UserProfile
{
    public class CreateUserProfileCommandHandler : CommandHandler<CreateUserProfileCommand, CreateUserProfileCommandResponse>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public override async Task<CreateUserProfileCommandResponse> Executor(CreateUserProfileCommand command)
        {
            var userProfile = new Domain.Profile.UserProfile(command.UserId, command.ProfileId, command.ProfileLogo, command.ProfileName, command.UserName, command.ProfileType )
            {
            };

            await _userProfileRepository.Create(userProfile);

            return new CreateUserProfileCommandResponse();
        }
    }
}
