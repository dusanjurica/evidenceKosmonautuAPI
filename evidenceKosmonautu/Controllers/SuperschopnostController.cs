using evidenceKosmonautu.BusinessCore;
using evidenceKosmonautu.DTOs;
using evidenceKosmonautu.Models;
using evidenceKosmonautu.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evidenceKosmonautu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperschopnostController : ControllerBase
    {
        private readonly IService<SuperpowerDTO> _superpowerService;

        public SuperschopnostController(IService<SuperpowerDTO> superpowerService)
        {
            _superpowerService = superpowerService;
        }

        [HttpGet]
        public IEnumerable<SuperpowerDTO> Get() => _superpowerService.GetAll();

        [HttpGet("{id}")]
        public SuperpowerDTO Get(int id) => _superpowerService.GetById(id);

        [HttpPost]
        public void Post([FromBody] SuperpowerDTO value) => _superpowerService.Create(value);

        [HttpPut]
        public void Put([FromBody] SuperpowerDTO value) => _superpowerService.Update(value);

        // DELETE api/<SuperschopnostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) => _superpowerService.Delete(id);
    }
}
