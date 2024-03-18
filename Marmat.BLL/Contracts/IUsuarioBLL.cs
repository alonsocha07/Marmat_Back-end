using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IUsuarioBLL : IDALGenerico<Usuario>
    {
        List<Usuario> GetByName(string Name);
    }
}
