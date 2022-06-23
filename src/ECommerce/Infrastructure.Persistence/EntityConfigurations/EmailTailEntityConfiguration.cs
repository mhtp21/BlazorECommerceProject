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
    public class EmailTailEntityConfiguration : BaseEntityConfiguration<EmailTail>
    {
        public override void Configure(EntityTypeBuilder<EmailTail> builder)
        {
            base.Configure(builder);
            builder.ToTable("emailtail", ECommerceContext.DEFAULT_SCHEMA);
        }
    }
}
