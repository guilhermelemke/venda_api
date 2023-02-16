using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        // Pode ser separado em pastas EntitiesConfiguration para cada entidade e chamada aqui
        // Ver CleanArchMvc
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Property(x => x.Id);

            modelBuilder.Entity<Seller>().Property(x => x.Id);
            modelBuilder.Entity<Seller>().Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");

            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Order>().Property(x => x.Id);
        }
    }
}
