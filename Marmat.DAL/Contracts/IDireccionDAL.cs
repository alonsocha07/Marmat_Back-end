using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IDireccionDAL :IDALGenerico<Direccion>
    {
        List<Direccion> GetByName(string Name);
    }
}
