using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<ICollection<T>> FindAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includeProperties = null
            );
        Task<T> Find(
            Expression<Func<T, bool>> expression = null,
            List<string> includeProperties = null
            );
        Task<bool> isExists(Expression<Func<T, bool>> expression = null);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
