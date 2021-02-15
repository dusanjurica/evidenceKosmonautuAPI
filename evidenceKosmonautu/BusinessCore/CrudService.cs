using evidenceKosmonautu.Repositories;
using System;
using System.Collections.Generic;

namespace evidenceKosmonautu.BusinessCore
{
    public class CrudService<T> : ICrudService<T>
        where T : class, IEntity
    {
        private readonly IUnitOfWork<T> _uow;
        private readonly IRepository<T> _repository;

        public CrudService(IUnitOfWork<T> uow, IRepository<T> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        void ICrudService<T>.Create(T entity) => _uow.RegisterAdded(entity).Commit();

        IEnumerable<T> ICrudService<T>.Read(Func<T, bool> predicate) => _repository.GetAll(predicate);

        void ICrudService<T>.Update(T entity) => _uow.RegisterModified(entity).Commit();

        void ICrudService<T>.Delete(uint id) => _uow.RegisterDeleted(id).Commit();
    }
}
