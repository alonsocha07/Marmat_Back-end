using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IEstadoBLL : IDALGenerico<Estado>
    {
        List<Estado> GetByName(string Name);
   
    }
}
