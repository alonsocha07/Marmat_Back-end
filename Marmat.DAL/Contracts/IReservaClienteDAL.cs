using BackEnd.Models;
using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IReservaClienteDAL : IDALGenerico<ReservaCliente>
    {
        List<Reserva> GetByName(string Name);
    }
}
