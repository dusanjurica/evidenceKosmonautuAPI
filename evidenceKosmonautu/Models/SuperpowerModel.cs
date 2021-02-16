using evidenceKosmonautu.BusinessCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evidenceKosmonautu.Models
{
    public class SuperpowerModel : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nazev { get; set; }

        public virtual ICollection<jt_superhero_superpower> jtHeroPower { get; set; }
    }
}
