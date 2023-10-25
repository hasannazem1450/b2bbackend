using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.MessageCodes;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.Authentication.Exceptions
{
    public sealed class UserNameOrPhoneNumberIsNotValidException : BusinessException
    {
        public UserNameOrPhoneNumberIsNotValidException()
            : base(ExceptionCodes.Identity.UserNameOrPhoneNumberIsNotValid)
        {
        }

        public override string? PersianMessage { get; } = "نام کاربری یا شماره تلفن صحیح نمیباشد .";
        public override string EnglishMessage { get; } = "UserName or PhoneNumber Is Not Valid !";
    }
}
