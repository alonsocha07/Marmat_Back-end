using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.BLL.Contracts
{
    public interface IDepartamentoBLL:IDALGenerico<Departamento>
    {
        List<Departamento> GetByName(string Name);
        List<Departamento> GetByIdCondominio(int idCondominio); 
    }
}
