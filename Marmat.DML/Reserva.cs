using System;
using System.Collections.Generic;

namespace Marmat.DML
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public DateTime FechaReserva { get; set; }
        public int? IdAreacomun { get; set; }

        public virtual Areacomun? IdAreacomunNavigation { get; set; }
    }
}
