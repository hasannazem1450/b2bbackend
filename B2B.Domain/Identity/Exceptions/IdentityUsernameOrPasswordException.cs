using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.MessageCodes;
using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common.Enums;

namespace B2B.Domain.Identity.Exceptions
{
    public sealed class IdentityUsernameOrPasswordException : BusinessException
    {
        public IdentityUsernameOrPasswordException()
            : base(ExceptionCodes.Identity.UsernameOrPasswordIncorrect)
        {
        }

        public override string EnglishMessage => "Username Or Password Is Incorrect !";
        public override string? PersianMessage => "نام کاربری یا کلمه عبور اشتباه است !";
    }
}
