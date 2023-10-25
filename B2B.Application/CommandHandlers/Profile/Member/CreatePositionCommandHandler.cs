using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.Position;
using B2B.Application.Contracts.Repository.Profile.Member;
using B2B.Domain.Identity.Exceptions;
using B2B.Domain.Profile.Member;
using B2B.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace B2B.Application.CommandHandlers.Profile.Member
{

    public class CreatePositionCommandHandler : CommandHandler<CreatePositionCommand, CreatePositionCommandResponse>
    {

        private readonly IPositionRepository _positionRepository;

        public CreatePositionCommandHandler(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public override async Task<CreatePositionCommandResponse> Executor(CreatePositionCommand command)
        {
            var position = new Position(command.Name);

            await _positionRepository.Create(position);

            return new CreatePositionCommandResponse();
        }
    }
}
