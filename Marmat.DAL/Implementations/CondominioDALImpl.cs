using Marmat.DAL.Contracts;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class CondominioDALImpl : ICondominioDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public CondominioDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public CondominioDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Condominio condominio)
        {
            try
            {
                using (UnidadDeTrabajo<Condominio> unidad = new UnidadDeTrabajo<Condominio>(context))
                {
                    unidad.genericDAL.Add(condominio);
                    RegistrarBitacora("Condominio creado con el nombre: \n\n"
                    + "Nombre: " + condominio.NombreCondominio + ", \n"
                    + "Numero de vacantes: " + condominio.Vacantes + ", \n"
                    + "Descripción: " + condominio.Descripcion + ", \n"
                    + "Dirección: " + condominio.IdDireccion);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Condominio> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        /// <summary>
        /// Metodo que permite obtener todos los condominios de la base de datos
        /// </summary>
        /// <returns>Lista de Condominios</returns>
        public IEnumerable<Condominio> GetAll()
        {
            try
            {
                IEnumerable<Condominio> condominio;
                using (UnidadDeTrabajo<Condominio> unidad = new UnidadDeTrabajo<Condominio>(context))
                {
                    condominio = unidad.genericDAL.GetAll();
                }
                return condominio;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Condominio> Find(Expression<Func<Condominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Condominio Get(int idCondominio)
        {
            try
            {
                Condominio condominio;
                using (UnidadDeTrabajo<Condominio> unidad = new UnidadDeTrabajo<Condominio>(context))
                {
                    condominio = unidad.genericDAL.Get(idCondominio);
                }
                return condominio;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Condominio> Get()
        {
            try
            {
                IEnumerable<Condominio> condominio;
                using (UnidadDeTrabajo<Condominio> unidad = new UnidadDeTrabajo<Condominio>(context))
                {
                    condominio = unidad.genericDAL.GetAll();
                }
                return condominio.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del condominio por nombre de la base de datos
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Condominio> GetByName(string name)
        {
            try
            {
                List<Condominio> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.Condominios
                             where x.NombreCondominio.Contains(name)
                             select x).ToList();
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Condominio> GetByProvincia(string provinciaid)
        {
            try
            {
                int id = Int32.Parse(provinciaid);
                List<Condominio> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from Con in context.Condominios
                             join dir in context.Direccions on Con.IdDireccion equals dir.IdDireccion
                             join dis in context.Distritos on dir.IdDistrito equals dis.IdDistrito
                             join can in context.Cantons on dis.IdCanton equals can.IdCanton
                             join prov in context.Provincia on can.IdProvincia equals prov.IdProvincia
                             where prov.IdProvincia == id
                             select Con).ToList();
                    //select x).ToList();
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetDireccion(int direccionId)
        {
            try
            {

                string direccion;

                using (context = new Condominios_MarmatContext())
                {
                    direccion = (from Con in context.Condominios
                                join dir in context.Direccions on Con.IdDireccion equals dir.IdDireccion
                                 join dis in context.Distritos on dir.IdDistrito equals dis.IdDistrito
                                 join can in context.Cantons on dis.IdCanton equals can.IdCanton
                                 join prov in context.Provincia on can.IdProvincia equals prov.IdProvincia
                                 where dir.IdDireccion == direccionId
                                select prov.NombreProvincia +", " + can.NombreCanton).FirstOrDefault().ToString();
                          
                }
                return direccion;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Condominio SingleOrDefault(Expression<Func<Condominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Condominio condominio)
        {
            Condominio anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Condominio> unidadBefore = new UnidadDeTrabajo<Condominio>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(condominio.IdCondominio);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Condominio> unidad = new UnidadDeTrabajo<Condominio>(context))
                {
                    unidad.genericDAL.Update(condominio);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla: Condominio modificada, los datos anteriores son: \n\n"
                    + "Nombre: " + anterior.NombreCondominio + ", \n"
                    + "Numero de vacantes: " + anterior.Vacantes + ", \n"
                    + "Descripción: " + anterior.Descripcion + ", \n"
                    + "Dirección: " + anterior.IdDireccion + ", \n"

                    + ", fueron cambiados por: \n\n"

                    + "Nombre: " + condominio.NombreCondominio + ", \n"
                    + "Numero de vacantes: " + condominio.Vacantes + ", \n"
                    + "Descripción: " + condominio.Descripcion + ", \n"
                    + "Dirección: " + condominio.IdDireccion);
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
        public bool Remove(Condominio condominio)
        {

            Condominio anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Condominio> unidadBefore = new UnidadDeTrabajo<Condominio>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(condominio.IdCondominio);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Condominio> unidad = new UnidadDeTrabajo<Condominio>(context))
                {

                    unidad.genericDAL.Remove(condominio);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla Condominio, datos borrados: \n\n"
                   + "Nombre: " + anterior.NombreCondominio + ", \n"
                    + "Numero de vacantes: " + anterior.Vacantes + ", \n"
                    + "Descripción: " + anterior.Descripcion + ", \n"
                    + "Dirección: " + anterior.IdDireccion);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Condominio> entities)
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


