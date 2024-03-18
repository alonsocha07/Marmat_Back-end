using Marmat.DAL.Contracts;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class DireccionDALImpl : IDireccionDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public DireccionDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public DireccionDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Direccion direccion)
        {
            try
            {
                using (UnidadDeTrabajo<Direccion> unidad = new UnidadDeTrabajo<Direccion>(context))
                {
                    unidad.genericDAL.Add(direccion);
                    RegistrarBitacora("Dirección creada con el nombre: \n\n"
                   + "Nombre: " + direccion.NombreDireccion + ", \n"
                   + "Id distrito: " + direccion.IdDistrito);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Direccion> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Direccion> Find(Expression<Func<Direccion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Direccion Get(int idDireccion)
        {
            try
            {
                Direccion direccion;
                using (UnidadDeTrabajo<Direccion> unidad = new UnidadDeTrabajo<Direccion>(context))
                {
                    direccion = unidad.genericDAL.Get(idDireccion);
                }
                return direccion;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Direccion> Get()
        {
            try
            {
                IEnumerable<Direccion> direccion;
                using (UnidadDeTrabajo<Direccion> unidad = new UnidadDeTrabajo<Direccion>(context))
                {
                    direccion = unidad.genericDAL.GetAll();
                }
                return direccion.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Direccion> GetAll()
        {
            try
            {
                IEnumerable<Direccion> direccion;
                using (UnidadDeTrabajo<Direccion> unidad = new UnidadDeTrabajo<Direccion>(context))
                {
                    direccion = unidad.genericDAL.GetAll();
                }
                return direccion;
            }
            catch (Exception)
            {
                throw;
            }
        }

        List<Direccion> IDireccionDAL.GetByName(string Name)
        {
            throw new NotImplementedException();
        }



        public List<Direccion> GetByName(string Name)
        {
            try
            {
                List<Direccion> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.Direccions
                             where x.NombreDireccion.Contains(Name)
                             select x).ToList();
                    //var listCantons = context.Cantons.Select(x => x.IdCanton == 3);
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Direccion SingleOrDefault(Expression<Func<Direccion, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Direccion direccion)
        {
            Direccion anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Direccion> unidadBefore = new UnidadDeTrabajo<Direccion>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(direccion.IdDireccion);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Direccion> unidad = new UnidadDeTrabajo<Direccion>(context))
                {
                    unidad.genericDAL.Update(direccion);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla: Dirección modificada, los datos anteriores son: \n\n"
                       + "ID: " + anterior.IdDireccion + ", \n"
                       + "Nombre" + anterior.NombreDireccion + ", \n"
                       + "Id distrito: " + anterior.IdDistrito + ", \n"

                       + ", fueron cambiados por: \n\n"

                       + "ID: " + direccion.IdDireccion + ", \n"
                       + "Nombre: " + direccion.NombreDireccion + ", \n"
                       + "Id distrito: " + direccion.IdDistrito);
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
        public bool Remove(Direccion direccion)
        {
            Direccion anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Direccion> unidadBefore = new UnidadDeTrabajo<Direccion>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(direccion.IdDireccion);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Direccion> unidad = new UnidadDeTrabajo<Direccion>(context))
                {
                    unidad.genericDAL.Remove(direccion);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla Dirección, datos borrados: \n\n"

                       + "ID: " + anterior.IdDireccion + ", \n"
                       + "Nombre: " + anterior.NombreDireccion + ", \n"
                       + "Id distrito: " + anterior.IdDistrito);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Direccion> entities)
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
