using evidenceKosmonautu.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evidenceKosmonautu.BusinessCore
{
    public class UnitOfWork<T> : IUnitOfWork<T>
        where T : class, IEntity
    {
        private bool disposedValue;

        private readonly IRepository<T> _repository;
        private readonly DbContext _context;

        private IList<T> _added;
        private IList<T> _modified;
        private IList<T> _deleted;
 
        public UnitOfWork(IRepository<T> repository, DbContext context)
        {
            _repository = repository;
            _context = context;

            _added = new List<T>();
            _modified = new List<T>();
            _deleted = new List<T>();
        }

        public void RegisterAdded(T Entity)
        {
            _added.Add(Entity);
        }

        public void RegisterModified(T Entity)
        {
            _modified.Add(Entity);
        }

        public void RegisterDeleted(T Entity)
        {
            _deleted.Add(Entity);
        }

        public void Commit()
        {
            foreach(var added in this._added)
                _repository.Add(added);

            foreach (var modified in this._modified)
                _repository.Update(modified);

            foreach (var removed in this._deleted)
                _repository.Delete(removed.Id);

            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
