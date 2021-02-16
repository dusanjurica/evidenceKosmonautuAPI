using evidenceKosmonautu.BusinessCore;
using evidenceKosmonautu.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace evidenceKosmonautu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvidenceController : CrudControllerBase<jt_superhero_superpower>
    {
        public EvidenceController(ICrudService<jt_superhero_superpower> crudService) : base(crudService)
        {
        }

        // GET: api/<EvidenceController>
        [HttpGet]
        public IEnumerable<jt_superhero_superpower> Get()
        {
            return _crudService.Read(p => true);
        }

        // GET api/<EvidenceController>/5
        [HttpGet("{id}")]
        public IEnumerable<jt_superhero_superpower> Get(int id)
        {
            return
                _crudService.Read(p => p.Id == id);
        }

        // POST api/<EvidenceController>
        [HttpPost]
        public void Post([FromBody] jt_superhero_superpower value)
        {
            _crudService.Create(value);
        }

        // PUT api/<EvidenceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] jt_superhero_superpower value)
        {
            _crudService.Update(value);
        }

        // DELETE api/<EvidenceController>/5
        [HttpDelete("{id}")]
        public void Delete(uint id)
        {
            _crudService.Delete(id);
        }
    }
}
