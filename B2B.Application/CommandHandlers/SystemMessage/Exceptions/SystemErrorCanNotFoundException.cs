using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.MessageCodes;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.SystemMessage.Exceptions
{
    public sealed class SystemErrorCanNotFoundException : BusinessException
    {
        public SystemErrorCanNotFoundException()
            : base(ExceptionCodes.SystemMessage.SystemErrorCanNotFound)
        {
        }

        public override string EnglishMessage => "Can not found system error!";
        public override string? PersianMessage => "ارور ناشناخته ای رخ داد !";

    }
}
