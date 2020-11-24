using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace PasswordManager.Data
{
    public class PasswordManagerDatabaseContext : DbContext
    {

        //public PasswordManagerDatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=PasswordManagerDatabaseContext.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<>
            modelBuilder.Entity<Account>()
                .HasOne(u => u.Owner)
                .WithMany(u => u.Accounts)
                .HasForeignKey(u => u.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
