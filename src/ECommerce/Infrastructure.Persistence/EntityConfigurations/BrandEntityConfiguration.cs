using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class BrandEntityConfiguration : BaseEntityConfiguration<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            base.Configure(builder);

            builder.ToTable("brand", ECommerceContext.DEFAULT_SCHEMA);
        }
    }
}
