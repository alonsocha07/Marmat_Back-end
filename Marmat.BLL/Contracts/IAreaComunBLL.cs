using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IAreaComunBLL : IDALGenerico<Areacomun>
    {
        List<Areacomun> GetByName(string Name);
    }
}
