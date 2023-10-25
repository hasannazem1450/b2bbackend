using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.MessageCodes
{
    public sealed class ApplicationExceptionMessageCode : ExceptionMessageCode
    {
        public ApplicationExceptionMessageCode(int code) : base("ApplicationException", code)
        {
        }

        public static implicit operator ApplicationExceptionMessageCode(int first)
        {
            return new ApplicationExceptionMessageCode(first);
        }
    }
}
