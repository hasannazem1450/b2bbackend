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
    public class UpdateUserHandler : CommandHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private readonly UserManager<B2B.Domain.Identity.ApplicationUser> _userManager;

        public UpdateUserHandler(UserManager<B2B.Domain.Identity.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public override async Task<UpdateUserCommandResponse> Executor(UpdateUserCommand command)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == command.UserName);

            if (user == null)
                throw new IdentityException("کاربر مورد نظر وجود ندارد !", "User is not exist !");

            user.UserName = command.List.UserName;
            user.NormalizedUserName = command.List.NormalizedUserName;
            user.Email = command.List.Email;
            user.EmailConfirmed = command.List.EmailConfirmed;
            user.PasswordHash = command.List.PasswordHash;
            user.SecurityStamp = command.List.SecurityStamp;
            user.ConcurrencyStamp = command.List.ConcurrencyStamp;
            user.PhoneNumber = command.List.PhoneNumber;
            user.PhoneNumberConfirmed = command.List.PhoneNumberConfirmed;
            user.TwoFactorEnabled = command.List.TwoFactorEnabled;
            user.LockoutEnabled = command.List.LockoutEnabled;
            user.AccessFailedCount = command.List.AccessFailedCount;

            

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new UpdateUserCommandResponse()
                {
                    Message = "User has been updated successfully"
                };
            }

            throw new IdentityException(null, result.Errors.First().Description);

        }
    }
}
