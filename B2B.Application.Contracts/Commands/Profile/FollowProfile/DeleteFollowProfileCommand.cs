﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.Profile.FollowProfile
{
    public class DeleteFollowProfileCommand : Command
    {
        public int Id { get; set; }
    }

    public class DeleteFollowProfileCommandResponse : CommandResponse
    {
    }
}
