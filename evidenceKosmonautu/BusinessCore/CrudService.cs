using evidenceKosmonautu.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        void ICrudService<T>.Create(T entity)
        {
            throw new NotImplementedException();
        }

        void ICrudService<T>.Delete(uint id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> ICrudService<T>.Read(Func<T, bool> predicate)
        {
            return _repository.GetAll(predicate);
        }

        void ICrudService<T>.Update(uint id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
