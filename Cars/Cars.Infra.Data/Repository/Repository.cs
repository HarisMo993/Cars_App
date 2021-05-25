using Cars.Domain.Interfaces;
using Cars.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        internal DbSet<T> _db;

        public Repository(DbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _db.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _db.Remove(entity);
        }

        public async Task<T> Find(Expression<Func<T, bool>> expression, List<string> includeProperties = null)
        {
            IQueryable<T> query = _db;

            if (includeProperties != null)
            {
                foreach (var table in includeProperties)
                {
                    query = query.Include(table);
                }
            }

            return await query.FirstOrDefaultAsync(expression);
        }

        public async Task<ICollection<T>> FindAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includeProperties = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includeProperties != null)
            {
                foreach (var table in includeProperties)
                {
                    query = query.Include(table);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> isExists(Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = _db;
            return await query.AnyAsync(expression);
        }

        public void Update(T entity)
        {
            _db.Update(entity);
        }
    }
}
