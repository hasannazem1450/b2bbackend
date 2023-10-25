﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.CommandHandlers.SystemMessage.Exceptions;
using B2B.Application.Contracts.Commands.SystemMessage;
using B2B.Application.Contracts.Repository;
using B2B.Domain.SystemMessages;
using B2B.Framework.Contracts.Abstracts;
using B2B.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;

namespace B2B.Application.CommandHandlers.SystemMessage
{
    public class UpdateSystemMessageCommandHandler
        : CommandHandler<UpdateSystemMessageCommand, CommandResponse>
    {
        private readonly ISystemMessageRepository _systemErrorRepository;
        private readonly UserManager<B2B.Domain.Identity.ApplicationUser> _userManager;


        public UpdateSystemMessageCommandHandler(ISystemMessageRepository systemErrorRepository, UserManager<B2B.Domain.Identity.ApplicationUser> userManager)
        {
            _systemErrorRepository = systemErrorRepository;
            _userManager = userManager;
        }

        public override async Task<CommandResponse> Executor(UpdateSystemMessageCommand command)
        {
            var found = await _systemErrorRepository.GetMessageByCodeAndType(command.Code, command.TypeMessage);

            if (found == null) throw new SystemErrorCanNotFoundException();

            var list = new List<SystemDataMessage>();

            foreach (var item in command.List)
            {
                var mess = new SystemDataMessage(item.MessageLanguage, item.Prefix, item.Message);

                list.Add(mess);
            }

            found.UpdateMessage(list);
           
            await _systemErrorRepository.Update(found);

            return (CommandResponseSuccessful.CreateSuccessful());
        }
    }
}
