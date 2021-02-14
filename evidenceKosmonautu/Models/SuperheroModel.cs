using System.Collections.Generic;
using evidenceKosmonautu.BusinessCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evidenceKosmonautu.Models
{
    public class SuperheroModel : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }

        public virtual ICollection<jt_superhero_superpower> Superpowers { get; set; }
    }
}
