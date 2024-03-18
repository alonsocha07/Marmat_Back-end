using System;
using System.Collections.Generic;

namespace Marmat.DML
{
    public partial class Ticket
    {
        public Ticket()
        {
            ComentarioTickets = new HashSet<ComentarioTicket>();
        }

        public int IdTicket { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdEstado { get; set; }
        public int IdUsuario { get; set; }
        public int IdDepartamento { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
        public virtual Estado IdEstadoNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<ComentarioTicket> ComentarioTickets { get; set; }
    }
}
