using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IComentarioTicketDAL :IDALGenerico<ComentarioTicket>
    {
        List<ComentarioTicket> GetByName(string Name);
       
    }
}
