using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.MessageCodes;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Domain.SystemMessages.Exceptions
{
    public sealed class SystemErrorMessageIsEmptyException : BusinessException
    {
        public SystemErrorMessageIsEmptyException()
            : base(ExceptionCodes.SystemMessage.SystemErrorMessageIsEmpty)
        {
        }

        public override string PersianMessage => "پیام ارور خالی میباشد";
        public override string EnglishMessage => "System error message is empty!";
    }
}
