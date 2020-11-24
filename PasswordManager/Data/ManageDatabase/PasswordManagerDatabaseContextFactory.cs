using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data
{
    public static class PasswordManagerDatabaseContextFactory
    {

        //private readonly string _connectionString;

        //public PasswordManagerDatabaseContextFactory(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        //public PasswordManagerDatabaseContext CreateDbContext()
        //{
        //    DbContextOptionsBuilder<PasswordManagerDatabaseContext> options = new DbContextOptionsBuilder<PasswordManagerDatabaseContext>();
        //    options.UseSqlite(_connectionString);
        //    return new PasswordManagerDatabaseContext();
        //}

        private static PasswordManagerDatabaseContext _passwordManagerDatabaseContext = null;

        public static PasswordManagerDatabaseContext DatabaseInstance
        {
            get
            {
                if (_passwordManagerDatabaseContext == null)
                {
                    _passwordManagerDatabaseContext = new PasswordManagerDatabaseContext();
                    _passwordManagerDatabaseContext.Database.EnsureCreated();
                }
                return _passwordManagerDatabaseContext;
            }
        }
    }
}
