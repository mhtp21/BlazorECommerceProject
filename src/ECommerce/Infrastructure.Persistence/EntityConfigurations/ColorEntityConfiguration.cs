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
    public class ColorEntityConfiguration : BaseEntityConfiguration<Color>
    {
        public override void Configure(EntityTypeBuilder<Color> builder)
        {
            base.Configure(builder);

            builder.ToTable("color", ECommerceContext.DEFAULT_SCHEMA);
        }
    }
}
