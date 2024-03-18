using Marmat.DML;
using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class ReservaCliente
    {
        public DateTime IdReserva { get; set; }
        public string IdCondominio { get; set; }
        public string IdAreaComun { get; set; }
        public string IdUsuario { get; set; } = null;
    }
}
