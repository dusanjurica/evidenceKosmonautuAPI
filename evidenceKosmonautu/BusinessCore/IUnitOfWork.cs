using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evidenceKosmonautu.BusinessCore
{
    public interface IUnitOfWork<T> : IDisposable
        where T : class, IEntity
    {
        IEnumerable<T> Added { get; set; }
        IEnumerable<T> Modified { get; set; }
        IEnumerable<T> Removed { get; set; }

        void Commit();
    }
}
