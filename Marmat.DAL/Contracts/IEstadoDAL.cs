using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IEstadoDAL : IDALGenerico<Estado>
    {
        List<Estado> GetByName(string Name);
   
    }
}
