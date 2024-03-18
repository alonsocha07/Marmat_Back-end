using System;
using System.Collections.Generic;

namespace Marmat.DML
{
    public partial class Bitacora
    {
        public int IdBitacora { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
