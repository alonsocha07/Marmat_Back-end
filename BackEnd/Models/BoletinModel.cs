namespace BackEnd.Models
{
    public class BoletinModel
    {
        public int IdBoletin { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Comentario { get; set; } = null!;
    }
}
