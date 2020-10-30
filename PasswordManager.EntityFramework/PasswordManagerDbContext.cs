using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.EntityFramework
{
    public class PasswordManagerDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public PasswordManagerDbContext(DbContextOptions options) : base(options) { }
    }
}
