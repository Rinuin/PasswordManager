using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Data
{
    public abstract class DataManager<T> where T : DomainObject
    {
        //private readonly PasswordManagerDatabaseContextFactory _contextFactory;
        protected readonly PasswordManagerDatabaseContext _context;
        protected readonly NonQueryDataManager<T> _nonQueryDataManager;

        public DataManager()
        {
            _context = PasswordManagerDatabaseContextFactory.DatabaseInstance;
            _nonQueryDataManager = new NonQueryDataManager<T>(_context);
        }

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataManager.Create(entity);
        }

        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataManager.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataManager.Delete(id);
        }

        public async Task<T> Get(int id)
        {
            //using (PasswordManagerDatabaseContext context = _context.CreateDbContext())
            //{
            //    T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            //    return entity;
            //}
            T entity = await _context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            //using (PasswordManagerDatabaseContext context = _context.CreateDbContext())
            //{
            //    IEnumerable<T> entities = await context.Set<T>().ToListAsync();
            //    return entities;
            //}

            IEnumerable<T> entities = await _context.Set<T>().ToListAsync();
            return entities;
        }

    }
}
