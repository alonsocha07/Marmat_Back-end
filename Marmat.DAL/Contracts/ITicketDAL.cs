using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface ITicketDAL : IDALGenerico<Ticket>
    {
        List<Ticket> GetByName(string Name);
    }
}
