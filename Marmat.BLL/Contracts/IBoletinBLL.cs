using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IBoletinBLL : IDALGenerico<Boletin>
    {
        List<Boletin> GetByName(string Name);
    }
}
