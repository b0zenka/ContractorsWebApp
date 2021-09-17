using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratorsWebAPI.Entities
{
    public class ContractorDbContext : DbContext
    {
        private string _connectionString = "server=localhost;database=ContractorsDataBase;user=root;password=123haslo@456";
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contractor>()
                .Property(c => c.ShortName)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Contractor>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Contractor>()
                .Property(c => c.NIP)
                .IsRequired()
                .HasMaxLength(10);
            modelBuilder.Entity<Address>()
                .Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(20);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }
    }
}
