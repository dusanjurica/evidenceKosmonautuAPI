using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evidenceKosmonautu.Models
{
    public class jt_superhero_superpower
    {
        public uint SuperpowerId { get; set; }
        public uint SuperheroId { get; set; }

        public SuperheroModel Superhero { get; set; }
        public SuperpowerModel Superpower { get; set; }
    }
}
