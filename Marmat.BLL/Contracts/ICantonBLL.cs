using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface ICantonBLL : IDALGenerico<Canton>
    {
        List<Canton> GetByName(string Name);
    }
}
