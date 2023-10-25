using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common.Enums;

namespace B2B.Domain.Sms;

public class SmsInfo : Entity<int>
{
    public SmsInfo(string senderNumber, string receiverNumber, string message, string code, SmsType smsType)
    {
        SenderNumber = senderNumber;
        ReceiverNumber = receiverNumber;
        Message = message;
        Code = code;
        SmsType = smsType;
    }

    public string SenderNumber { get; protected set; }
    public string ReceiverNumber { get; protected set; }
    public string Message { get; protected set; }
    public string Code { get; protected set; }
    public SmsType SmsType { get; protected set; }
}