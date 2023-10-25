using B2B.Application.Contracts.Repository.Sms;
using B2B.CommandDB;
using B2B.Domain.Sms;
using B2B.Framework.Contracts.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace B2B.CommandDb.Repository.Sms;

public class SmsInfoRepository : BaseRepository, ISmsInfoRepository
{
    public SmsInfoRepository(BaseProjectCommandDb db) : base(db)
    {
    }

    public async Task Create(SmsInfo smsInfo)
    {
        await _Db.SmsInfos.AddAsync(smsInfo);
        await _Db.SaveChangesAsync();
    }

    public async Task<SmsInfo> ReadLastByReceiverNumber(string receiverNumber, SmsType smsType)
    {
        var smsInfo = await _Db.SmsInfos.OrderByDescending(x => x.Id)
            .FirstOrDefaultAsync(x => x.ReceiverNumber == receiverNumber && x.SmsType == smsType);

        return smsInfo;
    }
}