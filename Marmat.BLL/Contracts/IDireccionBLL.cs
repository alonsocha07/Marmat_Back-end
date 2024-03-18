using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IDireccionBLL :IDALGenerico<Direccion>
    {
        List<Direccion> GetByName(string Name);
    }
}
