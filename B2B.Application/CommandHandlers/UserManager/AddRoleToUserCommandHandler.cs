using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.CommandHandlers.Exceptions;
using B2B.Application.Contracts.Commands.UserManager;
using B2B.Application.MessageCodes.IdentityPersianErrorsHandler;
using B2B.Domain.Identity.Exceptions;
using B2B.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace B2B.Application.CommandHandlers.UserManager
{
    public class AddRoleToUserCommandHandler : CommandHandler<AddRoleToUserCommand, AddRoleToUserCommandResponse>
    {
        private readonly UserManager<B2B.Domain.Identity.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddRoleToUserCommandHandler(UserManager<B2B.Domain.Identity.ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public override async Task<AddRoleToUserCommandResponse> Executor(AddRoleToUserCommand command)
        {
            var role = await _roleManager.FindByNameAsync(command.UserRoleName);
            if (role == null)
                throw new IdentityException("رول مورد نظر وجود ندارد !", "Role is not exist");

            var user = await _userManager.FindByNameAsync(command.UserName);
            if (role == null)
                throw new IdentityException("کاربر مورد نظر وجود ندارد !", "User is not exist");

            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return new AddRoleToUserCommandResponse()
                {
                    Code = 1,
                    Message = "User Role Has Been Created"
                };
            }

            throw new IdentityException(null, result.Errors.First().Description);
        }
    }
}
