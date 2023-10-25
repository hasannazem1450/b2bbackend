using B2B.Domain.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.CommandDb.EntitiesConfigurations.BaseInfo;

public class IndustrialParkConfiguration : IEntityTypeConfiguration<IndustrialPark>
{
    public void Configure(EntityTypeBuilder<IndustrialPark> builder)
    {
        builder.HasKey(x => x.Id);
    }
}