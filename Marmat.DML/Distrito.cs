using System;
using System.Collections.Generic;

namespace Marmat.DML
{
    public partial class Distrito
    {
        public Distrito()
        {
            Direccions = new HashSet<Direccion>();
        }

        public int IdDistrito { get; set; }
        public string NombreDistrito { get; set; } = null!;
        public int IdCanton { get; set; }

        public virtual Canton IdCantonNavigation { get; set; } = null!;
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}
