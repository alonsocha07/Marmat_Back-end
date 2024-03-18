using Marmat.DML;
using System;
using System.Collections.Generic;

namespace Marmat.DML
{
    public partial class Condominio
    {
        public Condominio()
        {
            Departamentos = new HashSet<Departamento>();
        }

        public int IdCondominio { get; set; }
        public string NombreCondominio { get; set; } = null!;
        public int Vacantes { get; set; }
        public string Descripcion { get; set; } = null!;
        public string? Imagen { get; set; }
        public int IdDireccion { get; set; }
        public int? IdAreacomun { get; set; }

        public virtual Areacomun? IdAreacomunNavigation { get; set; }
        public virtual Direccion IdDireccionNavigation { get; set; } = null!;
        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}
