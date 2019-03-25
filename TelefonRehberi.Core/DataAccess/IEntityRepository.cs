using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.Core
{
    public interface IEntityRepository<T> where T : class, IEntity, new()

    {
        T Get(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> key, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null);
        IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
