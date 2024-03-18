using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class DistritoDALImpl : IDistritoDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public DistritoDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public DistritoDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Distrito distrito)
        {
            try
            {
                using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(context))
                {
                    unidad.genericDAL.Add(distrito);
                    RegistrarBitacora("Distrito creado: \n\n"
                    + "Nombre: " + distrito.NombreDistrito + ", \n"
                    + "Id Cantón: " + distrito.IdCanton);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Distrito> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Distrito> Find(Expression<Func<Distrito, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Distrito Get(int idDistrito)
        {
            try
            {
                Distrito distrito;
                using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(context))
                {
                    distrito = unidad.genericDAL.Get(idDistrito);
                }
                return distrito;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Distrito> Get()
        {
            try
            {
                IEnumerable<Distrito> distrito;
                using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(context))
                {
                    distrito = unidad.genericDAL.GetAll();
                }
                return distrito.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Distrito> GetAll()
        {
            try
            {
                IEnumerable<Distrito> distrito;
                using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(context))
                {
                    distrito = unidad.genericDAL.GetAll();
                }
                return distrito;
            }
            catch (Exception)
            {
                throw;
            }
        }
        List<Distrito> IDistritoDAL.GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Distrito> GetByName(string Name)
        {
            try
            {
                List<Distrito> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.Distritos
                             where x.NombreDistrito.Contains(Name)
                             select x).ToList();

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Distrito SingleOrDefault(Expression<Func<Distrito, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Distrito distrito)
        {
            Distrito anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Distrito> unidadBefore = new UnidadDeTrabajo<Distrito>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(distrito.IdDistrito);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(context))
                {
                    unidad.genericDAL.Update(distrito);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla: Distrito modificada, los datos anteriores son: \n\n"
                       + "ID: " + anterior.IdDistrito + ", \n"
                       + "Nombre" + anterior.NombreDistrito + ", \n"
                       + "id Cantón: " + anterior.IdCanton + ", \n"

                       + ", fueron cambiados por: \n\n"

                       + "ID: " + distrito.IdDistrito + ", \n"
                       + "Nombre: " + distrito.NombreDistrito + ", \n"
                       + "Id Cantón: " + distrito.IdCanton);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }
        #endregion

        #region Delete
        public bool Remove(Distrito distrito)
        {
            Distrito anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Distrito> unidadBefore = new UnidadDeTrabajo<Distrito>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(distrito.IdDistrito);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(context))
                {
                    unidad.genericDAL.Remove(distrito);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla Distrito, datos borrados: \n\n"

                      + "ID: " + anterior.IdDistrito + ", \n"
                      + "Nombre: " + anterior.NombreDistrito + ", \n"
                      + "Id Cantón: " + anterior.IdCanton);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Distrito> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region AddBinnacle
        public bool RegistrarBitacora(string detalleBitacora)
        {
            using (var conexion = new Condominios_MarmatContext())
            {
                try
                {
                    Bitacora bitacora = new Bitacora();
                    bitacora.IdBitacora = 0;
                    bitacora.Descripcion = detalleBitacora;
                    bitacora.Fecha = DateTime.Now;
                    bitacora.IdUsuario = 1;

                    conexion.Bitacoras.Add(bitacora);
                    conexion.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
        }

        public bool LoginUser(string usuario, string pass)
        {
            throw new NotImplementedException();
        }

        public bool DateCheck(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public bool DateCheck(DateTime fecha, int areaComun)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
