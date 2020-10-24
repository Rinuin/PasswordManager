using Microsoft.EntityFrameworkCore;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace PasswordManager.Data
{
    public class PasswordManagerDatabseContext : DbContext
    {

        public PasswordManagerDatabseContext(DbContextOptions<PasswordManagerDatabseContext> options) : base(options) { }

        public DbSet<UserEntity> UserEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserEntity userEnt = new UserEntity();
            userEnt.Login = "Abc";
            userEnt.Password = "xyz";
            modelBuilder.Entity<UserEntity>().HasData(userEnt);
            base.OnModelCreating(modelBuilder);
        }
    }
}
