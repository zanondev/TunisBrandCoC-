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
    public class OrderEntityRepository
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductQuantity).IsRequired();
            builder.Property(p => p.OrderDate).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Product).IsRequired();
            builder.Property(p => p.TotalPrice).IsRequired();

           
        }
    }
}
