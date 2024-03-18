using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IDistritoBLL:IDALGenerico<Distrito>
    {
        List<Distrito> GetByName(string Name);
 
    }
}
