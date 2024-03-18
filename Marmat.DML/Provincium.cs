using System;
using System.Collections.Generic;

namespace Marmat.DML
{
    public partial class Provincium
    {
        public Provincium()
        {
            Cantons = new HashSet<Canton>();
        }

        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; } = null!;

        public virtual ICollection<Canton> Cantons { get; set; }
    }
}
