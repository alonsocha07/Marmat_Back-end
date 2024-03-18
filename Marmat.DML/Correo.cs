using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmat.DML
{
    public class Correo
    {
        public string nombre { get; set; }
        public string apellidos { get; set; } = null!;
        public string numero { get; set; } = null!;
        public string correo { get; set; } = null!;
        public string mensaje { get; set; } = null!;
    }
}
