using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IAreaComunDAL : IDALGenerico<Areacomun>
    {
        List<Areacomun> GetByName(string Name);
    }
}
