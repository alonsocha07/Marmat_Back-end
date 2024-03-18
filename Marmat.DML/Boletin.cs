using System;
using System.Collections.Generic;

namespace Marmat.DML
{ 
    public partial class Boletin
    {
        public int IdBoletin { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Comentario { get; set; } = null!;
    }
}
