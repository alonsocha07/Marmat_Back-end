using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IComentarioTicketBLL :IDALGenerico<ComentarioTicket>
    {
        List<ComentarioTicket> GetByName(string Name);
       
    }
}
