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
    public class PurchaseEntityRepository : BaseEntityConfiguration<Purchase>
    {
        public override void Configure(EntityTypeBuilder<Purchase> builder)
        {
            base.Configure(builder);

            builder.ToTable("purchase", ECommerceContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.CreateSold)
                .WithMany(i => i.Purchases)
                .HasForeignKey(i => i.UserId);

            builder.HasOne(i => i.Payment)
                .WithOne(i => i.Purchase)
                .HasForeignKey<Payment>(i => i.PurchaseId);
        }

    }
}
