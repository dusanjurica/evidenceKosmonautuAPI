using evidenceKosmonautu.BusinessCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evidenceKosmonautu.Models
{
    public class jt_superhero_superpower : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int SuperpowerId { get; set; }
        public int SuperheroId { get; set; }

        public SuperheroModel SuperheroModel { get; set; }
        public SuperpowerModel SuperpowerModel { get; set; }
    }
}
