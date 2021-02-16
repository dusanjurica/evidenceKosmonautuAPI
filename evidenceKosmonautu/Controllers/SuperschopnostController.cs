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
    public class SuperschopnostController : CrudControllerBase<SuperpowerModel>
    {

        public SuperschopnostController(ICrudService<SuperpowerModel> crudService) : base(crudService) { }

        // GET: api/<SuperschopnostController>
        [HttpGet]
        public IEnumerable<SuperpowerModel> Get()
        {
            return _crudService.Read(p => true);
        }

        // GET api/<SuperschopnostController>/5
        [HttpGet("{id}")]
        public IEnumerable<SuperpowerModel> Get(int id)
        {
            return _crudService.Read(p => p.Id == id);
        }

        // POST api/<SuperschopnostController>
        [HttpPost]
        public void Post([FromBody] SuperpowerModel value)
        {
            _crudService.Create(value);
        }

        // PUT api/<SuperschopnostController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] SuperpowerModel value)
        {
            _crudService.Update(value);
        }

        // DELETE api/<SuperschopnostController>/5
        [HttpDelete("{id}")]
        public void Delete(uint id)
        {
            _crudService.Delete(id);
        }
    }
}
