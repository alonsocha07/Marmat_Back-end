using System;
using System.Collections.Generic;

namespace Marmat.DML
{
    public partial class Direccion
    {
        public Direccion()
        {
            Condominios = new HashSet<Condominio>();
        }

        public int IdDireccion { get; set; }
        public string NombreDireccion { get; set; } = null!;
        public int IdDistrito { get; set; }

        public virtual Distrito IdDistritoNavigation { get; set; } = null!;
        public virtual ICollection<Condominio> Condominios { get; set; }
    }
}
