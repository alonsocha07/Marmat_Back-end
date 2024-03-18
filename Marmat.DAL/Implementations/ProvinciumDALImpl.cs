using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class ProvinciumDALImpl : IProvinciumDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public ProvinciumDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public ProvinciumDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Provincium provincia)
        {
            try
            {
                using (UnidadDeTrabajo<Provincium> unidad = new UnidadDeTrabajo<Provincium>(context))
                {
                    unidad.genericDAL.Add(provincia);
                    RegistrarBitacora("Provincia creada: \n\n"
                    + "Nombre: " + provincia.NombreProvincia);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Provincium> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Provincium> Find(Expression<Func<Provincium, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Provincium Get(int idProvincium)
        {
            try
            {
                Provincium provincia;
                using (UnidadDeTrabajo<Provincium> unidad = new UnidadDeTrabajo<Provincium>(context))
                {
                    provincia = unidad.genericDAL.Get(idProvincium);
                }
                return provincia;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Provincium> Get()
        {
            try
            {
                IEnumerable<Provincium> provincia;
                using (UnidadDeTrabajo<Provincium> unidad = new UnidadDeTrabajo<Provincium>(context))
                {
                    provincia = unidad.genericDAL.GetAll();
                }
                return provincia.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Provincium> GetAll()
        {
            try
            {
                IEnumerable<Provincium> provincia;
                using (UnidadDeTrabajo<Provincium> unidad = new UnidadDeTrabajo<Provincium>(context))
                {
                    provincia = unidad.genericDAL.GetAll();
                }
                return provincia;
            }
            catch (Exception)
            {
                throw;
            }
        }
        List<Provincium> IProvinciumDAL.GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Provincium> GetByName(string Name)
        {
            try
            {
                List<Provincium> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.Provincia
                             where x.NombreProvincia.Contains(Name)
                             select x).ToList();

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Provincium SingleOrDefault(Expression<Func<Provincium, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Provincium provincia)
        {
            Provincium anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Provincium> unidadBefore = new UnidadDeTrabajo<Provincium>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(provincia.IdProvincia);
                }
                context = new Condominios_MarmatContext();
                using (UnidadDeTrabajo<Provincium> unidad = new UnidadDeTrabajo<Provincium>(context))
                {
                    unidad.genericDAL.Update(provincia);
                    result = unidad.Complete();

                    RegistrarBitacora("Tabla: Provincia modificada, los datos anteriores son: \n\n"
                        + "ID: " + anterior.IdProvincia + ", \n"
                        + "Nombre" + anterior.NombreProvincia + ", \n"

                        + ", fueron cambiados por: \n\n"

                        + "ID: " + provincia.IdProvincia + ", \n"
                        + "Nombre: " + provincia.NombreProvincia);

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
        public bool Remove(Provincium provincia)
        {
            Provincium anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Provincium> unidadBefore = new UnidadDeTrabajo<Provincium>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(provincia.IdProvincia);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Provincium> unidad = new UnidadDeTrabajo<Provincium>(context))
                {
                    unidad.genericDAL.Remove(provincia);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla Provincia, datos borrados: \n\n"

                       + "ID: " + anterior.IdProvincia + ", \n"
                       + "Nombre: " + anterior.NombreProvincia);

                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Provincium> entities)
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
