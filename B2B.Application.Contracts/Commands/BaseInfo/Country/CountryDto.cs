﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.Contracts.Commands.BaseInfo.Country
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public int CountryCode { get; set; }
    }
}
