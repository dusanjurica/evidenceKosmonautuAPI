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
    public class KosmonautController : CrudControllerBase<SuperheroModel>
    {
        public KosmonautController(ICrudService<SuperheroModel> crudService) : base(crudService) { }

        [HttpGet]
        public IEnumerable<SuperheroModel> Get()
        {
            //return _superheroRepository.Get();

            return _crudService.Read(p => true);
        }

        // GET api/<HomeController>/5
        //[HttpGet("{id}")]
        //public IEnumerable<SuperheroModel> Get(int id)
        //{
        //    return _superheroRepository.GetAll(p => p.Id == id);
        //}

        // POST api/<HomeController>
        //[HttpPost]
        //public void Post([FromBody] SuperheroModel value)
        //{
        //    _uow.RegisterAdded(value);

        //    _uow.Commit();
        //}

        // PUT api/<HomeController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] SuperheroModel value)
        //{
        //    _uow.RegisterModified(value);

        //    _uow.Commit();
        //}

        // DELETE api/<HomeController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    //_uow.RegisterDeleted();

        //    //_uow.Commit();
        //}
    }
}
