using evidenceKosmonautu.BusinessCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace evidenceKosmonautu.Repositories
{
    public interface IRepository<T>
        where T : class, IEntity
    {
        IEnumerable<T> Get();
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        void Add(T Entity);
        void Update(T Entity);
        void Delete(uint EntityId);
    }

    public interface IAsyncComplexRepository<T>
        where T : class, IEntity
    {
        Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> predicate);
        Task AddSingleOrManyAsync(params T[] oneOrManyEntities);
        Task UpdateSingleOrManyAsync(params T[] oneOrManyEntities);
        Task DeleteSingleOrManyAsync(params T[] oneOrManyEntities);
    }

}
