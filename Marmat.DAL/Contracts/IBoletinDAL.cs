using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IBoletinDAL : IDALGenerico<Boletin>
    {
        List<Boletin> GetByName(string name);

    }
}
