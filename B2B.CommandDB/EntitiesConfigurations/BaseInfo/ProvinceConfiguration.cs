using B2B.Domain.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.CommandDb.EntitiesConfigurations.BaseInfo;

public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Country)
            .WithMany(x => x.Provinces)
            .HasForeignKey(x => x.CountryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}