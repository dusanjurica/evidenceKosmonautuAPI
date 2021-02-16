using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using evidenceKosmonautu.BusinessCore;
using evidenceKosmonautu.Repositories;
using evidenceKosmonautu.DTOs;
using evidenceKosmonautu.Database;
using evidenceKosmonautu.Services;

namespace evidenceKosmonautu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KosmonautController : ControllerBase
    {
        IService<SuperheroDTO> _kosmonautService;

        public KosmonautController(IService<SuperheroDTO> kosmonautService)
        {
            _kosmonautService = kosmonautService;
        }
        
        [HttpGet]
        public IEnumerable<SuperheroDTO> Get() => _kosmonautService.GetAll();
        
        [HttpGet("{id}")]
        public SuperheroDTO Get(int id) => _kosmonautService.GetById(id);
       
        [HttpPost]
        public void Post([FromBody] SuperheroDTO value) => _kosmonautService.Create(value);
        
        [HttpPut]
        public void Put([FromBody] SuperheroDTO value) => _kosmonautService.Update(value);
        
        [HttpDelete("{id}")]
        public void Delete(int id) => _kosmonautService.Delete(id);
    }
}
