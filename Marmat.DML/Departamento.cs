using System;
using System.Collections.Generic;

namespace Marmat.DML
{
    public partial class Departamento
    {
        public Departamento()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdDepartamento { get; set; }
        public int CantidadCuartos { get; set; }
        public int CantidadBanios { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Imagen { get; set; } = null!;
        public int? IdUsuario { get; set; }
        public int IdCondominio { get; set; }

        public virtual Condominio IdCondominioNavigation { get; set; } = null!;
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
