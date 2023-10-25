﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.UserManager
{
    public class DeleteUserRoleCommand : Command
    {
        public DeleteUserRoleCommand(string userName , string roleName)
        {
            UserName = userName;
            RoleName = roleName;
        }

        public string UserName { get; set; }
        public string RoleName { get; set; }
    }

    public class DeleteUserRoleCommandResponse : CommandResponse
    {
        public string Message { get; set; }
        public string Prefix { get; set; }
        public int Code { get; set; }
    }
}
