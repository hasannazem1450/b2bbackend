﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Framework.Contracts.MessageCode
{
    public sealed class FrameworkResponseMessageCode : ResponseMessageCode
    {
        public FrameworkResponseMessageCode(CodeAndMessage codeAndMessage) : base("FrameworkException", codeAndMessage.Code, codeAndMessage.Message)
        {
        }

        public static implicit operator FrameworkResponseMessageCode(CodeAndMessage codeAndMessage)
        {
            return new FrameworkResponseMessageCode(codeAndMessage);
        }
    }
}
