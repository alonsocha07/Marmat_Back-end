using BackEnd.Models;
using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IReservaClienteBLL : IDALGenerico<ReservaCliente>
    {
        List<Reserva> GetByName(string Name);
    }
}
