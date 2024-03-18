#region Using
using Marmat.DAL.Contracts;
using Marmat.DML;
using System.Linq.Expressions;

#endregion

namespace Marmat.DAL.Implementations
{
    public class BitacoraDALImpl : IBitacoraDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public BitacoraDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public BitacoraDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Bitacora entity)
        {
            try
            {
                using (UnidadDeTrabajo<Bitacora> unidad = new UnidadDeTrabajo<Bitacora>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Bitacora> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Bitacora> Find(Expression<Func<Bitacora, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Bitacora> Get()
        {
            try
            {
                IEnumerable<Bitacora> entity;
                using (UnidadDeTrabajo<Bitacora> unidad = new UnidadDeTrabajo<Bitacora>(context))
                {
                    entity = unidad.genericDAL.GetAll();
                }
                return entity.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Bitacora> GetAll()
        {
            try
            {
                IEnumerable<Bitacora> entity;
                using (UnidadDeTrabajo<Bitacora> unidad = new UnidadDeTrabajo<Bitacora>(context))
                {
                    entity = unidad.genericDAL.GetAll();
                }
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Bitacora Get(int idBitacora)
        {
            try
            {
                Bitacora entity;
                using (UnidadDeTrabajo<Bitacora> unidad = new UnidadDeTrabajo<Bitacora>(context))
                {
                    entity = unidad.genericDAL.Get(idBitacora);
                }
                return entity;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Bitacora> GetByName(string Name)
        {
            try
            {
                List<Bitacora> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.Bitacoras
                             where x.Descripcion.Contains(Name)
                             select x).ToList();

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Bitacora SingleOrDefault(Expression<Func<Bitacora, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Bitacora bitacora)
        {
            Bitacora bitacoraAnterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Bitacora> unidadBefore = new UnidadDeTrabajo<Bitacora>(context))
                {
                    bitacoraAnterior = unidadBefore.genericDAL.Get(bitacora.IdBitacora);
                }
                context = new Condominios_MarmatContext();
                using (UnidadDeTrabajo<Bitacora> unidad = new UnidadDeTrabajo<Bitacora>(context))
                {
                    unidad.genericDAL.Update(bitacora);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla: Bitácora, modificada los datos anteriores son: \n\n"
                        + "ID: " + bitacoraAnterior.IdBitacora + ", \n"
                        + "Descripción: " + bitacoraAnterior.Descripcion + ", \n"
                        + "Fecha: " + bitacoraAnterior.Fecha + ", \n"
                        + "Id Usuario: " + bitacoraAnterior.IdUsuario + ", \n"

                        + ", fueron cambiados por: \n\n"

                        + "ID: " + bitacora.IdBitacora + ", \n"
                        + "Descripción: " + bitacora.Descripcion + ", \n"
                        + "Fecha: " + bitacora.Fecha + ", \n"
                        + "Id Usuario: " + bitacora.IdUsuario);
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
        public bool Remove(Bitacora entity)
        {
            Bitacora bitacoraAnterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Bitacora> unidadBefore = new UnidadDeTrabajo<Bitacora>(context))
                {
                    bitacoraAnterior = unidadBefore.genericDAL.Get(entity.IdBitacora);
                }
                context = new Condominios_MarmatContext();
                using (UnidadDeTrabajo<Bitacora> unidad = new UnidadDeTrabajo<Bitacora>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla Bitácora, datos borrados: \n\n"

                      + "ID: " + bitacoraAnterior.IdBitacora + ", \n"
                        + "Descripción: " + bitacoraAnterior.Descripcion + ", \n"
                        + "Fecha: " + bitacoraAnterior.Fecha + ", \n"
                        + "Id Usuario: " + bitacoraAnterior.IdUsuario);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Bitacora> entities)
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
