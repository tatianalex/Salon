using Domen.Models;
using Microsoft.EntityFrameworkCore;

namespace Domen;

public class AplicationContext : DbContext
{
      /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Salon;Username=postgres;Password=1");
        }*/
      public AplicationContext(DbContextOptions<AplicationContext> options) : base(options)
      {
        
      }

        public DbSet<User> Users { get; set; }
        public DbSet<ThRecord> ThRecords { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Scheldule> Scheldules { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Material?> Materials { get; set; }
        public DbSet<MailToken> MailTokens { get; set; }
        public DbSet<Chart> Charts { get; set; }
        public DbSet<CategoryService> CategoryService { get; set; }
        public DbSet<CategoryMaterials> CategoryMaterials { get; set; }
        public DbSet<CalculationCard> CalculationCards { get; set; }
        public DbSet<Calculation> Calculations { get; set; }
      
}