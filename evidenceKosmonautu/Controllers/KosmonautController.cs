using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using evidenceKosmonautu.BusinessCore;
using evidenceKosmonautu.Models;

namespace evidenceKosmonautu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KosmonautController : CrudControllerBase<SuperheroModel>
    {
        public KosmonautController(ICrudService<SuperheroModel> crudService) : base(crudService) { }

        [HttpGet]
        public IEnumerable<SuperheroModel> Get()
        {
            return _crudService.Read(p => true);
        }

        [HttpGet("{id}")]
        public IEnumerable<SuperheroModel> Get(int id)
        {
            return _crudService.Read(p => p.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] SuperheroModel value)
        {
            _crudService.Create(value);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] SuperheroModel value)
        {
            _crudService.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(uint id)
        {
            _crudService.Delete(id);
        }
    }
}
