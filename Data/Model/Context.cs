using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(""); // MySQL connection string goes here
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.FullName).IsRequired().HasColumnType("varchar(50)");
                entity.Property(e => e.Email).IsRequired().HasColumnType("varchar(50)");
                entity.Property(e => e.Phone).IsRequired().HasColumnType("varchar(9)");
                entity.Property(e => e.IsAdmin).IsRequired().HasColumnType("bool");
                entity.Property(e => e.UserName).IsRequired().HasColumnType("varchar(50)");
                entity.Property(e => e.Password).HasColumnType("varchar(64)");
                entity.Property(e => e.Salt).IsRequired().HasColumnType("varchar(5)");
            });
        }
    }
}