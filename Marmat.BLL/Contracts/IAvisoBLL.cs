using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IAvisoBLL : IDALGenerico<Aviso>
    {
        List<Aviso> GetByName(string Name);
    }
}
