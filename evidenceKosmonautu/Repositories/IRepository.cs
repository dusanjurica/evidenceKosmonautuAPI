using evidenceKosmonautu.BusinessCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evidenceKosmonautu.Repositories
{
    public interface IRepository<T>
        where T : class, IEntity
    {
        IEnumerable<T> Get();
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        int Add(T Entity);
        int Update(T Entity);
        int Delete(uint EntityId);
    }
}
