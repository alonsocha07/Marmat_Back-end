using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IReservalBLL : IDALGenerico<Reserva>
    {
        List<Reserva> GetByName(string Name);
    }
}
