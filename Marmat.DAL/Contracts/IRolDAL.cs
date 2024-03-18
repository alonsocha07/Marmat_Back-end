using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IRolDAL : IDALGenerico<Rol>
    {
        List<Rol> GetByName(string Name);
    }
}
