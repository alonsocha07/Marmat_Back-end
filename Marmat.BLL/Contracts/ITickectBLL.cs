using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface ITickectBLL : IDALGenerico<Ticket>
    {
        List<Ticket> GetByName(string Name);
    }
}
