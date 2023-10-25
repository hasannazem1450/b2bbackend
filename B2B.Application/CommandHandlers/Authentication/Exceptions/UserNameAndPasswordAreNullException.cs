using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.MessageCodes;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.Authentication.Exceptions
{
    public sealed class UserNameAndPasswordAreNullException : BusinessException
    {
        public UserNameAndPasswordAreNullException()
            : base(ExceptionCodes.Identity.UserNameOrPhoneNumberIsNullOrEmpty)
        {
        }

        public override string? PersianMessage { get; } = "نام کاربری یا شماره تلفن خالی میباشد .";
        public override string EnglishMessage { get; } = "UserName or PhoneNumber Is Empty .";
    }
}
