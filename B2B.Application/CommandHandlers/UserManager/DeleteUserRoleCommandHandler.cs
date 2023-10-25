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
    public class DeleteUserRoleCommandHandler : CommandHandler<DeleteUserRoleCommand, DeleteUserRoleCommandResponse>
    {
        private readonly UserManager<B2B.Domain.Identity.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DeleteUserRoleCommandHandler(UserManager<B2B.Domain.Identity.ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public override async Task<DeleteUserRoleCommandResponse> Executor(DeleteUserRoleCommand command)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == command.UserName);
            if (user == null)
                throw new IdentityException("کاربر مورد نظر وجود ندارد !", "User is not exist");

            var role = await _roleManager.FindByNameAsync(command.RoleName);

            if (role == null)
                throw new IdentityException("رول مورد نظر وجود ندارد !", "Role is not exist");

            var result = await _userManager.RemoveFromRoleAsync(user, command.RoleName);

            if (result.Succeeded)
            {
                return new DeleteUserRoleCommandResponse()
                {
                    Message = "User Role has been deleted successfully"
                };
            }

            throw new IdentityException(null, result.Errors.First().Description);

        }
    }
}
