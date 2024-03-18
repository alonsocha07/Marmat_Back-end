using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface ICantonDAL : IDALGenerico<Canton>
    {
        List<Canton> GetByName(string Name);

    }
}
