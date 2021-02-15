using evidenceKosmonautu.BusinessCore;
using Microsoft.AspNetCore.Mvc;

namespace evidenceKosmonautu.Controllers
{
    public abstract class CrudControllerBase<T> : ControllerBase
        where T : class, IEntity
    {
        protected readonly ICrudService<T> _crudService;

        protected CrudControllerBase(ICrudService<T> crudService)
        {
            _crudService = crudService;
        }
    }
}
