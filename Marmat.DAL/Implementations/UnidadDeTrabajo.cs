using Marmat.DAL.Contracts;
using Marmat.DML;

namespace Marmat.DAL.Implementations
{
    #region Unidad de trabajo

    public class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        private readonly Condominios_MarmatContext context;

        public IDALGenerico<T> genericDAL;

        public UnidadDeTrabajo(Condominios_MarmatContext _context)
        {
            context = _context;
            genericDAL = new DALGenericoImpl<T>(context);
        }

        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
    #endregion
}
