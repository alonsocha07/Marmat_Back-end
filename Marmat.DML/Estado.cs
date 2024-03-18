using System;
using System.Collections.Generic;

namespace Marmat.DML
{
    public partial class Estado
    {
        public Estado()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
