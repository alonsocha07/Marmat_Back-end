using Marmat.DAL.Contracts;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class CantonDALImpl : ICantonDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public CantonDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public CantonDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Canton entity)
        {
            try
            {
                using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(context))
                {
                    unidad.genericDAL.Add(entity);
                    RegistrarBitacora("Cantón creado: \n\n"
                    + "Nombre: " + entity.NombreCanton + ", \n"
                    + "Id Provincia: " + entity.IdProvincia);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Canton> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Canton> Find(Expression<Func<Canton, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Canton Get(int idCanton)
        {
            try
            {
                Canton entity;
                using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(context))
                {
                    entity = unidad.genericDAL.Get(idCanton);
                }
                return entity;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Canton> Get()
        {
            try
            {
                IEnumerable<Canton> entity;
                using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(context))
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

        public IEnumerable<Canton> GetAll()
        {
            try
            {
                IEnumerable<Canton> entity;
                using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(context))
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
        List<Canton> ICantonDAL.GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Canton> GetByName(string Name)
        {
            try
            {
                List<Canton> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.Cantons
                             where x.NombreCanton.Contains(Name)
                             select x).ToList();
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Canton SingleOrDefault(Expression<Func<Canton, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update

        public bool Update(Canton entity)
        {
            Canton anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Canton> unidadBefore = new UnidadDeTrabajo<Canton>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(entity.IdCanton);
                }
                context = new Condominios_MarmatContext();
                using (UnidadDeTrabajo<Canton> unidadAfter = new UnidadDeTrabajo<Canton>(context))
                {
                    unidadAfter.genericDAL.Update(entity);
                    result = unidadAfter.Complete();
                    RegistrarBitacora("Tabla: Cantón modificada, los datos anteriores son: \n\n"
                        + "ID: " + anterior.IdCanton + ", \n"
                        + "Nombre" + anterior.NombreCanton + ", \n"
                        + "Id Provincia: " + anterior.IdProvincia + ", \n"

                        + ", fueron cambiados por: \n\n"

                        + "ID: " + entity.IdCanton + ", \n"
                        + "Nombre: " + entity.NombreCanton + ", \n"
                        + "Id Provincia: " + entity.IdProvincia);
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
        public bool Remove(Canton entity)
        {
            Canton anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Canton> unidadBefore = new UnidadDeTrabajo<Canton>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(entity.IdCanton);
                }
                context = new Condominios_MarmatContext();
                using (UnidadDeTrabajo<Canton> unidadAfter = new UnidadDeTrabajo<Canton>(context))
                {
                    unidadAfter.genericDAL.Remove(entity);
                    result = unidadAfter.Complete();
                    RegistrarBitacora("Tabla cantón, datos borrados: \n\n"

                       + "ID: " + anterior.IdCanton + ", \n"
                       + "Nombre: " + anterior.NombreCanton + ", \n"
                       + "Id Provincia: " + anterior.IdProvincia);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Canton> entities)
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
