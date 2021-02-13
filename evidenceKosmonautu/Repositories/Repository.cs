using evidenceKosmonautu.BusinessCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evidenceKosmonautu.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            this._context = context;
        }

        int IRepository<T>.Add(T Entity)
        {
            _context.Set<T>().Add(Entity);

            return 0;
        }

        int IRepository<T>.Delete(uint EntityId)
        {
            T entity2delete = _context.Set<T>().FirstOrDefault(f => f.Id == EntityId);

            if (entity2delete != null)
            {
                _context.Set<T>().Remove(entity2delete);
                return 0;
            }
            else
            {
                return -1;
            }
        }

        IEnumerable<T> IRepository<T>.Get()
        {
            return _context.Set<T>();
        }

        IEnumerable<T> IRepository<T>.GetAll(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        int IRepository<T>.Update(T Entity)
        {
            _context.Set<T>().Update(Entity);

            return 0;
        }
    }
}
