﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.CommandDb.EntitiesConfigurations.News
{
    public class EventConfiguration : IEntityTypeConfiguration<Domain.News.News>
    {
        public void Configure(EntityTypeBuilder<Domain.News.News> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.SmeProfile)
                .WithMany(x => x.News)
                .HasForeignKey(x => x.SmeProfileId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
