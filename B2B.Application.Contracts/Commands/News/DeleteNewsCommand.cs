﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.News
{
    public class DeleteNewsCommand : Command
    {
        public int Id { get; set; }
    }

    public class DeleteNewsCommandResponse : CommandResponse
    {
    }
}
