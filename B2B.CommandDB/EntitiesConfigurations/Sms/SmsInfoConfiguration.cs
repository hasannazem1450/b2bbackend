using B2B.Domain.Sms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.CommandDb.EntitiesConfigurations.Sms;

public class SmsInfoConfiguration : IEntityTypeConfiguration<SmsInfo>
{
    public void Configure(EntityTypeBuilder<SmsInfo> builder)
    {
    }
}