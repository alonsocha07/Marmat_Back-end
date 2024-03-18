using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class EstadoDALImpl : IEstadoDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public EstadoDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public EstadoDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Estado estado)
        {
            try
            {
                using (UnidadDeTrabajo<Estado> unidad = new UnidadDeTrabajo<Estado>(context))
                {
                    unidad.genericDAL.Add(estado);
                    RegistrarBitacora("Estado creado: \n\n"
                    + "Nombre: " + estado.NombreEstado);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Estado> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Estado> Find(Expression<Func<Estado, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Estado Get(int idEstado)
        {
            try
            {
                Estado estado;
                using (UnidadDeTrabajo<Estado> unidad = new UnidadDeTrabajo<Estado>(context))
                {
                    estado = unidad.genericDAL.Get(idEstado);
                }
                return estado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Estado> Get()
        {
            try
            {
                IEnumerable<Estado> estado;
                using (UnidadDeTrabajo<Estado> unidad = new UnidadDeTrabajo<Estado>(context))
                {
                    estado = unidad.genericDAL.GetAll();
                }
                return estado.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Estado> GetAll()
        {
            try
            {
                IEnumerable<Estado> estado;
                using (UnidadDeTrabajo<Estado> unidad = new UnidadDeTrabajo<Estado>(context))
                {
                    estado = unidad.genericDAL.GetAll();
                }
                return estado;
            }
            catch (Exception)
            {
                throw;
            }
        }
        List<Estado> IEstadoDAL.GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Estado> GetByName(string Name)
        {
            try
            {
                List<Estado> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.Estados
                             where x.NombreEstado.Contains(Name)
                             select x).ToList();

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Update
        public bool Update(Estado estado)
        {
            Estado anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Estado> unidadBefore = new UnidadDeTrabajo<Estado>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(estado.IdEstado);
                }
                using (UnidadDeTrabajo<Estado> unidad = new UnidadDeTrabajo<Estado>(context))
                {
                    unidad.genericDAL.Update(estado);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla: Estado modificada, los datos anteriores son: \n\n"
                        + "ID: " + anterior.IdEstado + ", \n"
                        + "Nombre" + anterior.NombreEstado + ", \n"
                        
                        + ", fueron cambiados por: \n\n"

                        + "ID: " + estado.IdEstado + ", \n"
                        + "Nombre: " + estado.NombreEstado);
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
        public bool Remove(Estado estado)
        {
            Estado anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Estado> unidadBefore = new UnidadDeTrabajo<Estado>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(estado.IdEstado);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Estado> unidad = new UnidadDeTrabajo<Estado>(context))
                {
                    unidad.genericDAL.Remove(estado);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla Estado, datos borrados: \n\n"

                       + "ID: " + anterior.IdEstado + ", \n"
                       + "Nombre: " + anterior.NombreEstado);

                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Estado> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region SingleOrDefault
        public Estado SingleOrDefault(Expression<Func<Estado, bool>> predicate)
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
