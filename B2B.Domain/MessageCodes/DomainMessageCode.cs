using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Domain.MessageCodes
{
    public sealed class DomainExceptionMessageCode : ExceptionMessageCode
    {
        public DomainExceptionMessageCode(int code) : base("DomainException", code)
        {
        }

        public static implicit operator DomainExceptionMessageCode(int first)
        {
            return new DomainExceptionMessageCode(first);
        }
    }
}
