using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class RolDALImpl : IRolDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public RolDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public RolDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Rol rol)
        {
            try
            {
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
                {
                    unidad.genericDAL.Add(rol);
                    RegistrarBitacora("Rol creado: \n\n"
                    + "Nombre: " + rol.NombreRol);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Rol> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Rol> Find(Expression<Func<Rol, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Rol Get(int idRol)
        {
            try
            {
                Rol rol;
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
                {
                    rol = unidad.genericDAL.Get(idRol);
                }
                return rol;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Rol> Get()
        {
            try
            {
                IEnumerable<Rol> rol;
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
                {
                    rol = unidad.genericDAL.GetAll();
                }
                return rol.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Rol> GetAll()
        {
            try
            {
                IEnumerable<Rol> rol;
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
                {
                    rol = unidad.genericDAL.GetAll();
                }
                return rol;
            }
            catch (Exception)
            {
                throw;
            }
        }
        List<Rol> IRolDAL.GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Rol> GetByName(string Name)
        {
            try
            {
                List<Rol> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.Rols
                             where x.NombreRol.Contains(Name)
                             select x).ToList();

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Rol SingleOrDefault(Expression<Func<Rol, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Rol rol)
        {
            Rol anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Rol> unidadBefore = new UnidadDeTrabajo<Rol>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(rol.IdRol);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
                {
                    unidad.genericDAL.Update(rol);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla: rol modificada, los datos anteriores son: \n\n"
                        + "ID: " + anterior.IdRol + ", \n"
                        + "Nombre" + anterior.NombreRol + ", \n"

                        + ", fueron cambiados por: \n\n"

                        + "ID: " + rol.IdRol + ", \n"
                        + "Nombre: " + rol.NombreRol + ", \n");
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
        public bool Remove(Rol rol)
        {
            Rol anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Rol> unidadBefore = new UnidadDeTrabajo<Rol>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(rol.IdRol);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
                {
                    unidad.genericDAL.Remove(rol);
                    result = unidad.Complete();

                    RegistrarBitacora("Tabla rol, datos borrados: \n\n"

                       + "ID: " + anterior.IdRol + ", \n"
                       + "Nombre: " + anterior.NombreRol + ", \n");
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Rol> entities)
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
