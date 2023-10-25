using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.CommandHandlers.Exceptions;
using B2B.Application.Contracts.Commands.Authentication;
using B2B.Application.Contracts.Commands.UserManager;
using B2B.Domain.Identity;
using B2B.Domain.Identity.Exceptions;
using B2B.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace B2B.Application.CommandHandlers.UserManager
{
    public class CreateUserCommandHandler : CommandHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly UserManager<B2B.Domain.Identity.ApplicationUser> _userManager;

        public CreateUserCommandHandler(UserManager<B2B.Domain.Identity.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public override async Task<CreateUserCommandResponse> Executor(CreateUserCommand command)
        {
            var user = new ApplicationUser
            {
                UserName = command.UserName,
                Email = command.Email,
            };

            var userCreate = await _userManager.CreateAsync(user, command.Password);
            if (userCreate.Succeeded)
            {
                return new CreateUserCommandResponse()
                {
                    Code = 1,
                    Message = "User Has Been Created"
                };
            }

            throw new IdentityException(null, userCreate.Errors.First().Description);

        }
    }
}
