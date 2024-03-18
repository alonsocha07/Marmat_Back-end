using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IDistritoDAL:IDALGenerico<Distrito>
    {
        List<Distrito> GetByName(string Name);
 
    }
}
