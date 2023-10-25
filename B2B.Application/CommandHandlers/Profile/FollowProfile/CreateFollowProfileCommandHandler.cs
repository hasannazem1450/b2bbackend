using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.FollowProfile;
using B2B.Application.Contracts.Repository.Profile.IFollowProfileRepository;
using B2B.Framework.Contracts.Abstracts;
using B2B.Domain.Profile.FollowProfile;


namespace B2B.Application.CommandHandlers.Profile.FollowProfile
{
    public class CreateFollowProfileCommandHandler : CommandHandler<CreateFollowProfileCommand, CreateFollowProfileCommandResponse>
    {

        private readonly IFollowProfileRepository _followProfileRepository;

        public CreateFollowProfileCommandHandler(IFollowProfileRepository followProfileRepository)
        {
            _followProfileRepository = followProfileRepository;
        }

        public override async Task<CreateFollowProfileCommandResponse> Executor(CreateFollowProfileCommand command)
        {
            var followProfile = new Domain.Profile.FollowProfile.FollowProfile(command.FollowProfileId,command.MyProfileId,command.FollowProfileName,command.FollowProfileLogo) { };

            await _followProfileRepository.Create(followProfile);

            return new CreateFollowProfileCommandResponse();
        }
    }
}
