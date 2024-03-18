using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class AreacomunDALImpl : IAreaComunDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public AreacomunDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public AreacomunDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Areacomun areaComun)
        {
            try
            {
                using (UnidadDeTrabajo<Areacomun> unidad = new UnidadDeTrabajo<Areacomun>(context))
                {
                    unidad.genericDAL.Add(areaComun);
                    RegistrarBitacora("area comun creada: \n\n"
                    + "Nombre: " + areaComun.NombreAreacomun);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Areacomun> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Areacomun> Find(Expression<Func<Areacomun, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Areacomun Get(int idAreaComun)
        {
            try
            {
                Areacomun areaComun;
                using (UnidadDeTrabajo<Areacomun> unidad = new UnidadDeTrabajo<Areacomun>(context))
                {
                    areaComun = unidad.genericDAL.Get(idAreaComun);
                }
                return areaComun;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Areacomun> Get()
        {
            try
            {
                IEnumerable<Areacomun> areaComun;
                using (UnidadDeTrabajo<Areacomun> unidad = new UnidadDeTrabajo<Areacomun>(context))
                {
                    areaComun = unidad.genericDAL.GetAll();
                }
                return areaComun.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Areacomun> GetAll()
        {
            try
            {
                IEnumerable<Areacomun> areaComun;
                using (UnidadDeTrabajo<Areacomun> unidad = new UnidadDeTrabajo<Areacomun>(context))
                {
                    areaComun = unidad.genericDAL.GetAll();
                }
                return areaComun;
            }
            catch (Exception)
            {
                throw;
            }
        }
        List<Areacomun> IAreaComunDAL.GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Areacomun> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Areacomun SingleOrDefault(Expression<Func<Areacomun, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Areacomun areaComun)
        {
            Areacomun anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Areacomun> unidadBefore = new UnidadDeTrabajo<Areacomun>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(areaComun.IdAreacomun);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Areacomun> unidad = new UnidadDeTrabajo<Areacomun>(context))
                {
                    unidad.genericDAL.Update(areaComun);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla: rol modificada, los datos anteriores son: \n\n"
                        + "ID: " + anterior.IdAreacomun + ", \n"
                        + "Nombre" + anterior.NombreAreacomun + ", \n"

                        + ", fueron cambiados por: \n\n"

                        + "ID: " + areaComun.IdAreacomun + ", \n"
                        + "Nombre: " + areaComun.NombreAreacomun + ", \n");
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
        public bool Remove(Areacomun areaComun)
        {
            Areacomun anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Areacomun> unidadBefore = new UnidadDeTrabajo<Areacomun>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(areaComun.IdAreacomun);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Areacomun> unidad = new UnidadDeTrabajo<Areacomun>(context))
                {
                    unidad.genericDAL.Remove(areaComun);
                    result = unidad.Complete();

                    RegistrarBitacora("Tabla Area Comun, datos borrados: \n\n"

                       + "ID: " + anterior.IdAreacomun + ", \n"
                       + "Nombre: " + anterior.NombreAreacomun + ", \n");
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Areacomun> entities)
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
