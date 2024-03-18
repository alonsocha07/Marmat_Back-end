using System;
using System.Collections.Generic;

namespace Marmat.DML
{
    public partial class Areacomun
    {
        public Areacomun()
        {
            Condominios = new HashSet<Condominio>();
            Reservas = new HashSet<Reserva>();
        }

        public int IdAreacomun { get; set; }
        public string NombreAreacomun { get; set; } = null!;

        public virtual ICollection<Condominio> Condominios { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
