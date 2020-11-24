using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Data
{
    public class NonQueryDataManager<T> where T : DomainObject
    {

        //private readonly PasswordManagerDatabaseContextFactory _contextfactory;
        private readonly PasswordManagerDatabaseContext _context;
        public NonQueryDataManager(PasswordManagerDatabaseContext contextfactory)
        {
            _context = contextfactory;
        }
        public async Task<T> Create(T entity)
        {
            using (PasswordManagerDatabaseContext context = _context)
            {
                EntityEntry<T> createdResult = await context.Set<T>()
                                                 .AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (PasswordManagerDatabaseContext context = _context)
            {
                entity.Id = id;

                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (PasswordManagerDatabaseContext context = _context)
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

    }
}
