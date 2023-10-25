using B2B.Application.MessageCodes;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.Authentication.Exceptions;

public sealed class UserNotExistException : BusinessException
{
    public UserNotExistException()
        : base(ExceptionCodes.Identity.UserNotExist)
    {
    }

    public override string? PersianMessage { get; } = "کاربر وجود ندارد .";
    public override string EnglishMessage { get; } = "User not exist .";
}