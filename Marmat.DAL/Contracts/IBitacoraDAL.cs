using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IBitacoraDAL : IDALGenerico<Bitacora>
    {
        List<Bitacora> GetByName(string name);
     
    }
}
