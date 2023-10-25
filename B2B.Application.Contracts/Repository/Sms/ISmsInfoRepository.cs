using B2B.Domain.Sms;
using B2B.Framework.Contracts.Common.Enums;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.Sms;

public interface ISmsInfoRepository : IRepository
{
    Task Create(SmsInfo smsInfo);
    Task<SmsInfo> ReadLastByReceiverNumber(string receiverNumber, SmsType smsType);
}