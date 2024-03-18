using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface ICondominioDAL : IDALGenerico<Condominio>
    {
        List<Condominio> GetByName(string Name);
        List<Condominio> GetByProvincia(string provinciaid);
        string GetDireccion(int direccionId);
    }
}
