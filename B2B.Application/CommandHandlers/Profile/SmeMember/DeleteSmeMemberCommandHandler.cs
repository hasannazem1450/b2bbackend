using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.SmeMember;
using B2B.Application.Contracts.Repository.Profile;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.Profile.SmeMember
{
    public class DeleteSmeMemberCommandHandler : CommandHandler<DeleteSmeMemberCommand, DeleteSmeMemberCommandResponse>
    {

        private readonly ISmeMemberRepository _smeMemberRepository;

        public DeleteSmeMemberCommandHandler(ISmeMemberRepository smeMemberRepository)
        {
            _smeMemberRepository = smeMemberRepository;
        }

        public override async Task<DeleteSmeMemberCommandResponse> Executor(DeleteSmeMemberCommand command)
        {

            await _smeMemberRepository.Delete(command.Id);

            return new DeleteSmeMemberCommandResponse();
        }
    }
}
