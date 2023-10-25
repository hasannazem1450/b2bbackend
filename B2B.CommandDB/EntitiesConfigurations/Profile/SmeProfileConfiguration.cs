using B2B.Domain.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.CommandDb.EntitiesConfigurations.Profile;

public class SmeProfileConfiguration : IEntityTypeConfiguration<SmeProfile>
{
    public void Configure(EntityTypeBuilder<SmeProfile> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.City)
            .WithMany(x => x.SmeProfiles)
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.SmeRank)
            .WithMany(x => x.SmeProfiles)
            .HasForeignKey(x => x.SmeRankId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(x => x.IndustrialPark)
            .WithMany(x => x.SmeProfiles)
            .HasForeignKey(x => x.IndustrialParkId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
    }
}