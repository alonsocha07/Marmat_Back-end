using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IRolBLL : IDALGenerico<Rol>
    {
        List<Rol> GetByName(string Name);
    }
}
