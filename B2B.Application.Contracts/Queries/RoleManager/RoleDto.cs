﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.Contracts.Queries.RoleManager
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name{ get; set; }
        public string NormalizedName { get; set; }
        public Guid ConcurrencyStamp { get; set; }
    }
}
