using B2B.Domain.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.CommandDb.EntitiesConfigurations.Profile;

public class SmeRaterConfiguration : IEntityTypeConfiguration<SmeRater>
{
    public void Configure(EntityTypeBuilder<SmeRater> builder)
    {
        builder.HasKey(x => x.Id);

    }
}