using System;

namespace evidenceKosmonautu.BusinessCore
{
    public interface IUnitOfWork<T> : IDisposable
        where T : class, IEntity
    {
        IUnitOfWork<T> RegisterAdded(T Entity);
        IUnitOfWork<T> RegisterModified(T Entity);
        IUnitOfWork<T> RegisterDeleted(uint id);

        void Commit();
    }
}
