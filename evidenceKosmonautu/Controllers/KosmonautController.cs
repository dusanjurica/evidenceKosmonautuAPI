using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evidenceKosmonautu.BusinessCore;
using evidenceKosmonautu.Models;
using evidenceKosmonautu.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace evidenceKosmonautu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KosmonautController : ControllerBase
    {
        private readonly IUnitOfWork<SuperheroModel> _uow;
        private readonly IRepository<SuperheroModel> _superheroRepository;

        public KosmonautController(IUnitOfWork<SuperheroModel> uow, IRepository<SuperheroModel> repository)
        {
            _uow = uow;
            _superheroRepository = repository;
        }


        // GET: api/<HomeController>
        [HttpGet]
        public IEnumerable<SuperheroModel> Get()
        {
            return _superheroRepository.Get();
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
