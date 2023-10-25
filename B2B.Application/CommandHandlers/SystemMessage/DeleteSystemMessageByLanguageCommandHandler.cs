using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.CommandHandlers.SystemMessage.Exceptions;
using B2B.Application.Contracts.Commands.SystemMessage;
using B2B.Application.Contracts.Repository;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.SystemMessage
{
    public class DeleteSystemMessageByLanguageCommandHandler
        : CommandHandler<DeleteSystemMessageByLanguageCommand, CommandResponse>
    {
        private readonly ISystemMessageRepository _systemErrorRepository;

        public DeleteSystemMessageByLanguageCommandHandler(ISystemMessageRepository systemErrorRepository)
        {
            _systemErrorRepository = systemErrorRepository;
        }

        public override async Task<CommandResponse> Executor(DeleteSystemMessageByLanguageCommand command)
        {
            var found = await _systemErrorRepository.GetMessageByCodeAndType(command.Code, command.TypeMessage);

            if (found == null) throw new SystemErrorCanNotFoundException();

            found.DeleteMessageByLanguage(command.ListLanguage);

            await _systemErrorRepository.Update(found);

            return (CommandResponseSuccessful.CreateSuccessful());
        }
    }
}
