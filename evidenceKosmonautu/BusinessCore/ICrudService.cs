using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evidenceKosmonautu.BusinessCore
{
    public interface ICrudService<T>
        where T : class, IEntity
    {
        IEnumerable<T> Read(Func<T, bool> predicate);
        void Create(T entity);
        void Update(uint id, T entity);
        void Delete(uint id);
    }
}
