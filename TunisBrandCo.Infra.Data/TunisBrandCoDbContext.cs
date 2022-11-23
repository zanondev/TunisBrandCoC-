using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TunisBrandCo.Domain.Features.Clients;
using TunisBrandCo.Domain.Features.Products;
using TunisBrandCo.Domain.Features.Orders;
using System.Collections.Generic;
using TunisBrandCo.Infra.Data.Features.Clients;
using TunisBrandCo.Infra.Data.Features.Orders;
using TunisBrandCo.Infra.Data.Features.Products;

namespace TunisBrandCo.Infra.Data
{
    public class TunisBrandCoDbContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source=SQLEXPRESS;initial catalog=MERCADODOZE;uid=sa;pwd= tunico;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityRepository());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }




}