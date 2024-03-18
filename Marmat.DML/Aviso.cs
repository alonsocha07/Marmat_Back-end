using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marmat.DML
{
    public partial class Aviso
    {
        [Key]
        public int IdAviso { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; } = null!;

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
