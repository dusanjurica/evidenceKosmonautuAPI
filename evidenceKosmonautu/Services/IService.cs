using evidenceKosmonautu.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evidenceKosmonautu.Services
{
    public interface IService<T>
        where T : class, IEntityDTO
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T dto);
        void Update(T dto);
        void Delete(int id);
    }
}
