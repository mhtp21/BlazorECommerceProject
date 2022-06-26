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
    public class OfferEntityConfiguration : BaseEntityConfiguration<Offer>
    {
        public override void Configure(EntityTypeBuilder<Offer> builder)
        {
            base.Configure(builder);

            builder.ToTable("offer", ECommerceContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.CreateOffer)
                .WithMany(i => i.Offers)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.Product)
                .WithMany(i => i.Offers)
                .HasForeignKey(i => i.ProductId);
        }
    }
}
