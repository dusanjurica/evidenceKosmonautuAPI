using evidenceKosmonautu.BusinessCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evidenceKosmonautu.DTOs
{
    public class SuperheroDTO : IEntityDTO
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }

        public IList<int> SuperschopnostiIds { get; set; }
        public IList<string> Superschopnosti { get; set; }
    }
}
