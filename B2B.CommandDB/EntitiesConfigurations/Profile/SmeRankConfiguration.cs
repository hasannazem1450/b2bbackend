using B2B.Domain.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.CommandDb.EntitiesConfigurations.Profile;

public class SmeRankConfiguration : IEntityTypeConfiguration<SmeRank>
{
    public void Configure(EntityTypeBuilder<SmeRank> builder)
    {
        builder.HasKey(x => x.Id);
    }
}