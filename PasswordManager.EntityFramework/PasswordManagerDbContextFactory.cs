using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.EntityFramework
{
    class PasswordManagerDbContextFactory : IDesignTimeDbContextFactory<PasswordManagerDbContext>
    {
        public PasswordManagerDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<PasswordManagerDbContext>();
            options.UseSqlite("Data Source=PasswordManagerDb.db");
            return new PasswordManagerDbContext(options.Options);
        }
    }
}
