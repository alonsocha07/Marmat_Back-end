using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IProvinciumBLL : IDALGenerico<Provincium>
    {
        List<Provincium> GetByName(string Name);

    }
}
