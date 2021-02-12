using System.Collections.Generic;

namespace evidenceKosmonautu.Models
{
    public class SuperheroModel
    {
        public uint Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }

        public virtual ICollection<jt_superhero_superpower> Superpowers { get; set; }
    }
}
