using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class BitacoraModel
    {
        public int ID_BITACORA { get; set; }
        public string DESCRIPCION { get; set; }
        public DateTime FECHA { get; set; }
        public int ID_USUARIO { get; set; }
    }
}
