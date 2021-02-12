using System.Collections.Generic;

namespace evidenceKosmonautu.Models
{
    public class SuperpowerModel
    {
        public uint Id { get; set; }
        public string Nazev { get; set; }

        public virtual ICollection<jt_superhero_superpower> Superheroes { get; set; }
    }
}
