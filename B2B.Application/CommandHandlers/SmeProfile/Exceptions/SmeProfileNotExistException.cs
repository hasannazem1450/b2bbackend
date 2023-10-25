using B2B.Application.MessageCodes;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.SmeProfile.Exceptions;

public sealed class SmeProfileNotExistException : BusinessException
{
    public SmeProfileNotExistException()
        : base(ExceptionCodes.SmeProfile.SmeProfileIsNotExist)
    {
    }

    public override string EnglishMessage => "SmeProfile Is Not Exist !";
    public override string? PersianMessage => "پروفایل وجود ندارد !";

}