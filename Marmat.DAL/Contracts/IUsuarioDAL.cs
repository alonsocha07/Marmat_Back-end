using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IUsuarioDAL : IDALGenerico<Usuario>
    {
        List<Usuario> GetByName(string Name);
    }
}
