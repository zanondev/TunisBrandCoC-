using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Clients;


namespace TunisBrandCo.Infra.Data.Features.Clients
{
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Cpf).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.LoyaltyPoints).IsRequired(); 


        }
    }
}
