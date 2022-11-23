using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Orders;

namespace TunisBrandCo.Infra.Data.Features.Orders
{
    public class OrderEntityRepository : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductQuantity).IsRequired();
            builder.Property(p => p.OrderDate).IsRequired();
            builder.Property(p => p.Status).IsRequired();

  
            builder.Property(p => p.TotalPrice).IsRequired();

            // Relationship
            builder.HasOne(p => p.Product).WithOne(o => o.Order).HasForeignKey<Order>(o => o.ProductId).IsRequired();

        }


    }
}