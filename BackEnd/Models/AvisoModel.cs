namespace BackEnd.Models
{
    public class AvisoModel
    {
        public int IdAviso { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; } = null!;
    }
}
