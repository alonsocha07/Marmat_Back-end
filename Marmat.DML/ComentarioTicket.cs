using System;
using System.Collections.Generic;

namespace Marmat.DML
{
    public partial class ComentarioTicket
    {
        public int IdComentarioTicket { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; } = null!;
        public int IdTicket { get; set; }

        public virtual Ticket IdTicketNavigation { get; set; } = null!;
    }
}
