using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IBitacoraBLL : IDALGenerico<Bitacora>
    {
        List<Bitacora> GetByName(string Name);
    }
}
