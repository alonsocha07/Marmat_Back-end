namespace BackEnd.Models
{
    public class TicketModel
    {
        public int IdTicket { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdEstado { get; set; }
        public int IdUsuario { get; set; }
        public int IdDepartamento { get; set; }
    }
}
