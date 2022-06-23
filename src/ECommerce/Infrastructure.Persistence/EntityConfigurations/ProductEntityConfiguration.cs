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
    public class ProductEntityConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.ToTable("product", ECommerceContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.CreatedBy)
                .WithMany(i => i.Products)
                .HasForeignKey(i => i.UserId);

            builder.HasOne(i => i.Brand)
                .WithMany(i => i.Products)
                .HasForeignKey(i => i.BrandId);

            builder.HasOne(i => i.Category)
                .WithMany(i => i.Products)
                .HasForeignKey(i => i.CategoryId);

            builder.HasOne(i => i.Color)
                .WithMany(i => i.Products)
                .HasForeignKey(i => i.ColorId);
        }
    }
}
