using evidenceKosmonautu.BusinessCore;
using System;
using System.Collections.Generic;

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
}
