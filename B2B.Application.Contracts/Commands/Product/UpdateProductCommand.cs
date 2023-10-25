﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.Product
{
    public class UpdateProductCommand : Command
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int SmeProfileId { get; set; }
    }

    public class UpdateProductCommandResponse : CommandResponse
    {
    }
}
