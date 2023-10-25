using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.MessageCodes;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Domain.SystemMessages.Exceptions
{
    public sealed class SystemErrorCodeIsInvalidException : BusinessException
    {

        public SystemErrorCodeIsInvalidException()
            : base(ExceptionCodes.SystemMessage.SystemErrorCodeIsInvalid)
        {
        }

        public override string PersianMessage => "کد ارور غیر معتبر میباشد";
        public override string EnglishMessage => "System error code is invalid!";
    }
}
