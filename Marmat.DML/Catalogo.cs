using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmat.DML
{
    public class Catalogo
    {
        public int IdCondominio { get; set; }
        public string NombreCondominio { get; set; } = null!;
        public int Vacantes { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Imagen { get; set; } = null!;
        public int IdDireccion { get; set; }

        public string nombre { get; set; } = null!;
        public string apellidos { get; set; } = null!;
        public string numero { get; set; } = null!;
        public string correo { get; set; } = null!;
        public string mensaje { get; set; } = null!;
    }
}
