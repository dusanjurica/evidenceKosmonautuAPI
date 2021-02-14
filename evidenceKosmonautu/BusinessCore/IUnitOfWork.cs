using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evidenceKosmonautu.BusinessCore
{
    public interface IUnitOfWork<T> : IDisposable
        where T : class, IEntity
    {
        void RegisterAdded(T Entity);
        void RegisterModified(T Entity);
        void RegisterDeleted(T Entity);

        void Commit();
    }
}
