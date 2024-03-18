using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface ICondominioBLL : IDALGenerico<Condominio>
    {
        List<Condominio> GetByName(string name);
        List<Condominio> GetByProvincia(string provinciaid);
        string GetDireccion(int direccionId);
    }
}
