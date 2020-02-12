using KickDo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KickDo.Data
{
    public class KickDoDB:DbContext
    {

        private string connectionString_ =
                "Server =localhost; Database=kickdo; Integrated Security = SSPI; Persist Security Info=False;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString_);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Company>()
                .ToTable("Company");
             
            modelBuilder
                   .Entity<Funding>()
                   .ToTable("Funding");

            modelBuilder
                   .Entity<Person>()
                   .ToTable("Person");

           modelBuilder
                   .Entity<Company>()
                   .HasIndex(c => c.VatNumber).IsUnique();

            modelBuilder
                  .Entity<Company>()
                  .Property(c => c.VatNumber)
                  .HasMaxLength(9)
                 .IsFixedLength();
       
        }
    }
}
