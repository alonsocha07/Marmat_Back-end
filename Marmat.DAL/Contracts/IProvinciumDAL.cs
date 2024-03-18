using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IProvinciumDAL : IDALGenerico<Provincium>
    {
        List<Provincium> GetByName(string Name);

    }
}
