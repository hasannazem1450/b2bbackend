using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Event;
using B2B.Application.Contracts.Commands.News;
using B2B.Application.Contracts.Repository.Event;
using B2B.Application.Contracts.Repository.News;
using B2B.Application.Contracts.Repository.Profile.Member;
using B2B.Domain.Profile.Member;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.Event
{
    public class DeleteEventInfoCommandHandler : CommandHandler<DeleteEventInfoCommand, DeleteEventInfoCommandResponse>
    {

        private readonly IEventInfoRepository _eventRepository;


        public DeleteEventInfoCommandHandler(IEventInfoRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public override async Task<DeleteEventInfoCommandResponse> Executor(DeleteEventInfoCommand command)
        {
            await _eventRepository.Delete(command.Id);

            return new DeleteEventInfoCommandResponse();
        }
    }
}
