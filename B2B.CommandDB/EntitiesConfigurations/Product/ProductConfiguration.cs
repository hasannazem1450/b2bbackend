using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.ProductBase;

namespace B2B.CommandDb.EntitiesConfigurations.Product
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.ProductBase.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.ProductBase.Product> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
