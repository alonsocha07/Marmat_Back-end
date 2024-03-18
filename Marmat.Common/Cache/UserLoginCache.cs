
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class UserLoginCache
    {
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; } = null!;
        public static string Correo { get; set; } = null!;
        public static string Pass { get; set; } = null!;
        public static string Nombre { get; set; } = null!;
        public static string PrimerApellido { get; set; } = null!;
        public static string SegundoApellido { get; set; } = null!;
        public static int NumeroTel { get; set; }
        public static int IdRol { get; set; }
    }
}
