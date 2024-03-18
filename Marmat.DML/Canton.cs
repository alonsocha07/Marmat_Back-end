using System;
using System.Collections.Generic;

namespace Marmat.DML
{
    public partial class Canton
    {
        public Canton()
        {
            Distritos = new HashSet<Distrito>();
        }

        public int IdCanton { get; set; }
        public string NombreCanton { get; set; } = null!;
        public int IdProvincia { get; set; }

        public virtual Provincium IdProvinciaNavigation { get; set; } = null!;
        public virtual ICollection<Distrito> Distritos { get; set; }
    }
}
