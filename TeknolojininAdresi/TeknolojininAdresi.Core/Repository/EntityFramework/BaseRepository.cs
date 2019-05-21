using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Core.Entities;

namespace TeknolojininAdresi.Core.Repository.EntityFramework
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChangesAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter = null)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public T Find(int id)
        {
            System.Threading.Thread.Sleep(3000);
            return _context.Set<T>().Find(id);
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return await _context.Set<T>().ToListAsync();
            }
            else
            {
                return await _context.Set<T>().Where(filter).ToListAsync();
            }
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public DbSet<T> Set()
        {
            return _context.Set<T>();
        }
    }
}
