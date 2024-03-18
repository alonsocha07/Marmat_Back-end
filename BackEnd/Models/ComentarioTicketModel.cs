namespace BackEnd.Models
{
    public class ComentarioTicketModel
    {
        public int IdComentarioTicket { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; } = null!;
        public int IdTicket { get; set; }
    }
}
