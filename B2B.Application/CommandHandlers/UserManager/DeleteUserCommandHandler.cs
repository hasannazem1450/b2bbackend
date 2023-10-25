using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.CommandHandlers.Exceptions;
using B2B.Application.Contracts.Commands.UserManager;
using B2B.Domain.Identity.Exceptions;
using B2B.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace B2B.Application.CommandHandlers.UserManager
{
    public class DeleteUserCommandHandler : CommandHandler<DeleteUserCommand, DeleteUserCommandResponse>
    {
        private readonly UserManager<B2B.Domain.Identity.ApplicationUser> _userManager;

        public DeleteUserCommandHandler(UserManager<B2B.Domain.Identity.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public override async Task<DeleteUserCommandResponse> Executor(DeleteUserCommand command)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == command.UserName);
            if (user == null)
                return new DeleteUserCommandResponse()
                {
                    Message = "User is not exist"
                };

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return new DeleteUserCommandResponse()
                {
                    Message = "User has been deleted successfully"
                };
            }

            throw new IdentityException(null, result.Errors.First().Description);

        }
    }
}
