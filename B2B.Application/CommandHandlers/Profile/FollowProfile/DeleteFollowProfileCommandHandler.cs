using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.FollowProfile;
using B2B.Application.Contracts.Repository.Profile.IFollowProfileRepository;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.Profile.FollowProfile
{
    public class DeleteFollowProfileCommandHandler : CommandHandler<DeleteFollowProfileCommand, DeleteFollowProfileCommandResponse>
    {
        private readonly IFollowProfileRepository _followProfileRepository;

        public DeleteFollowProfileCommandHandler(IFollowProfileRepository followProfileRepository)
        {
            _followProfileRepository = followProfileRepository;
        }

        public override async Task<DeleteFollowProfileCommandResponse> Executor(DeleteFollowProfileCommand command)
        {

            await _followProfileRepository.Delete(command.Id);

            return new DeleteFollowProfileCommandResponse();
        }
    }
}
