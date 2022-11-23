using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TunisBrandCo.Domain.Features.Clients;
using TunisBrandCo.Domain.Features.Products;
using TunisBrandCo.Domain.Features.Orders;

namespace TunisBrandCo.Infra.Data
{
    public class TunisBrandCoDbContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source=SQLEXPRESS;initial catalog=MERCADODOZE;uid=sa;pwd= tunico;");
    }


}

