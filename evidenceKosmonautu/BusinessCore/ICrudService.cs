using System;
using System.Collections.Generic;

namespace evidenceKosmonautu.BusinessCore
{
    public interface ICrudService<T>
        where T : class, IEntity
    {
        void Create(T entity);
        IEnumerable<T> Read(Func<T, bool> predicate);
        void Update(T entity);
        void Delete(uint id);
    }
}
