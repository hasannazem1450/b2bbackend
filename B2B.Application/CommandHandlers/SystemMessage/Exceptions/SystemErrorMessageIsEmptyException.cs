using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.MessageCodes;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.SystemMessage.Exceptions
{
    public sealed class SystemErrorMessageIsEmptyException : BusinessException
    {
        public SystemErrorMessageIsEmptyException()
            : base(ExceptionCodes.SystemMessage.SystemErrorMessageIsEmpty)
        {
        }

        public override string EnglishMessage => "Can not create system error when messages is empty!";
        public override string? PersianMessage => "نمیتوان اروری را با پیام خالی ثبت کرد !";

    }
}
