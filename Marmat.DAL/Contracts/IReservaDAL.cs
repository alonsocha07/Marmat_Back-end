using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IReservaDAL : IDALGenerico<Reserva>
    {
        List<Reserva> GetByName(string Name);
    }
}
