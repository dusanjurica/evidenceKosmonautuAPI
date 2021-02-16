using evidenceKosmonautu.BusinessCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evidenceKosmonautu.DTOs
{
    public class SuperpowerDTO : IEntityDTO
    {
        public int Id { get; set; }
        public string Nazev { get; set; }

        public IList<int> SuperheroesIds { get; set; }
        public IList<string> Superheroes { get; set; }
    }
}
