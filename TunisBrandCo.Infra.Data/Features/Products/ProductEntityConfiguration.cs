using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Clients;
using TunisBrandCo.Domain.Features.Products;

namespace TunisBrandCo.Infra.Data.Features.Products
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.StockQuantity).IsRequired();
            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.ExpiryDate).IsRequired();
            


        }
    }
}