using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.Position;
using B2B.Application.Contracts.Repository.Profile.Member;
using B2B.Domain.Profile.Member;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.Profile.Member
{

    public class DeletePositionCommandHandler : CommandHandler<DeletePositionCommand, DeletePositionCommandResponse>
    {

        private readonly IPositionRepository _positionRepository;

        public DeletePositionCommandHandler(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public override async Task<DeletePositionCommandResponse> Executor(DeletePositionCommand command)
        {

            await _positionRepository.Delete(command.Id);

            return new DeletePositionCommandResponse();
        }
    }
}
