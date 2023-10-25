using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.MessageCodes;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Domain.Identity.Exceptions
{
    public sealed class CreateRoleException : BusinessException
    {
        public CreateRoleException(string message)
            : base(ExceptionCodes.Roll.CreateRollError)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
