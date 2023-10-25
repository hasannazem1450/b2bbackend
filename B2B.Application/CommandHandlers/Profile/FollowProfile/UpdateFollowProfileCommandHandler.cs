using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.FollowProfile;
using B2B.Application.Contracts.Repository.Profile.IFollowProfileRepository;
using B2B.Application.Contracts.Repository.Profile.IFollowProfileRepository;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.Profile.FollowProfile
{
    public class UpdateFollowProfileCommandHandler : CommandHandler<UpdateFollowProfileCommand, UpdateFollowProfileCommandResponse>
    {
        private readonly IFollowProfileRepository _followProfileRepository;

        public UpdateFollowProfileCommandHandler(IFollowProfileRepository followProfileRepository)
        {
            _followProfileRepository = followProfileRepository;
        }

        public override async Task<UpdateFollowProfileCommandResponse> Executor(UpdateFollowProfileCommand command)
        {
            var followProfile = new Domain.Profile.FollowProfile.FollowProfile();

            await _followProfileRepository.Update(followProfile);

            return new UpdateFollowProfileCommandResponse();
        }
    }
}
