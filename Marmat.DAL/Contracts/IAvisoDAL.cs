using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IAvisoDAL : IDALGenerico<Aviso>
    {
        List<Aviso> GetByName(string name);

    }
}
