using Marmat.DML;

namespace Marmat.DAL.Contracts
{
    public interface IDepartamentoDAL:IDALGenerico<Departamento>
    {
        List<Departamento> GetByName(string Name);
        List<Departamento> GetByIdCondominio(int idCondominio); 
    }
}
