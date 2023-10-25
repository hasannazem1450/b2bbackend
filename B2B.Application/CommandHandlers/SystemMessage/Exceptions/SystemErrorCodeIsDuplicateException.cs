using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.MessageCodes;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.SystemMessage.Exceptions
{
    public sealed class SystemErrorCodeIsDuplicateException : BusinessException
    {
        public SystemErrorCodeIsDuplicateException()
            : base(ExceptionCodes.SystemMessage.SystemErrorCodeIsDuplicate)
        {
        }

        public override string EnglishMessage => "System error code is duplicate!";
        public override string? PersianMessage => "کد ارور مورد نظر وجود دارد !";

    }
}
