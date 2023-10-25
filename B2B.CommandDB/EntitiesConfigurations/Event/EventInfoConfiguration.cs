﻿using B2B.Domain.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.CommandDb.EntitiesConfigurations.Event;

public class EventInfoConfiguration : IEntityTypeConfiguration<EventInfo>
{
    public void Configure(EntityTypeBuilder<EventInfo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Province)
            .WithMany(x => x.EventsInfos)
            .HasForeignKey(x => x.ProvinceId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}