using Marmat.DAL.Contracts;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class DepartamentoDALImpl : IDepartamentoDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public DepartamentoDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public DepartamentoDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Departamento departamento)
        {
            try
            {
                using (UnidadDeTrabajo<Departamento> unidad = new UnidadDeTrabajo<Departamento>(context))
                {
                    unidad.genericDAL.Add(departamento);
                    RegistrarBitacora("Departamento creado con el detalle: \n\n"
                    + "Cuartos: " + departamento.CantidadCuartos + ", \n"
                    + "Baños: " + departamento.CantidadBanios + ", \n"
                    + "Descripción: " + departamento.Descripcion + ", \n"
                    + "Id Usuario: " + departamento.IdUsuario + ", \n"
                    + "Id Condominio: " + departamento.IdCondominio);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Departamento> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Departamento> Find(Expression<Func<Departamento, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Departamento Get(int idDepartamento)
        {
            try
            {
                Departamento departamento;
                using (UnidadDeTrabajo<Departamento> unidad = new UnidadDeTrabajo<Departamento>(context))
                {
                    departamento = unidad.genericDAL.Get(idDepartamento);
                }
                return departamento;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Departamento> Get()
        {
            try
            {
                IEnumerable<Departamento> departamento;
                using (UnidadDeTrabajo<Departamento> unidad = new UnidadDeTrabajo<Departamento>(context))
                {
                    departamento = unidad.genericDAL.GetAll();
                }
                return departamento.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Departamento> GetAll()
        {
            try
            {
                IEnumerable<Departamento> departamento;
                using (UnidadDeTrabajo<Departamento> unidad = new UnidadDeTrabajo<Departamento>(context))
                {
                    departamento = unidad.genericDAL.GetAll();
                }
                return departamento;
            }
            catch (Exception)
            {
                throw;
            }
        }
        List<Departamento> IDepartamentoDAL.GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Departamento> GetByName(string Name)
        {
            try
            {
                List<Departamento> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.Departamentos
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

        
        public List<Departamento> GetByIdCondominio(int idCondominio)
        {
            try
            {
                List<Departamento> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.Departamentos
                             where x.IdCondominio == idCondominio
                             select x).ToList();

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Departamento SingleOrDefault(Expression<Func<Departamento, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Departamento departamento)
        {
            Departamento anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Departamento> unidadBefore = new UnidadDeTrabajo<Departamento>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(departamento.IdDepartamento);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Departamento> unidad = new UnidadDeTrabajo<Departamento>(context))
                {
                    unidad.genericDAL.Update(departamento);
                    result = unidad.Complete();

                    RegistrarBitacora("Tabla: Departamento modificada, los datos anteriores son: \n\n"

                        + "ID: " + anterior.IdDepartamento + ", \n"
                        + "Cuartos: " + anterior.CantidadCuartos + ", \n"
                        + "Baños: " + anterior.CantidadBanios + ", \n"
                        + "Descripción: " + anterior.Descripcion + ", \n"
                        + "Id Usuario: " + anterior.IdUsuario + ", \n"
                        + "Id Condominio: " + anterior.IdCondominio + ", \n"

                        + ", fueron cambiados por: \n\n"

                        + "ID: " + departamento.IdDepartamento + ", \n"
                        + "Cuartos: " + departamento.CantidadCuartos + ", \n"
                        + "Baños: " + departamento.CantidadBanios + ", \n"
                        + "Descripción: " + departamento.Descripcion + ", \n"
                        + "Id Usuario: " + departamento.IdUsuario + ", \n"
                        + "Id Condominio: " + departamento.IdCondominio);

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
        public bool Remove(Departamento departamento)
        {
            Departamento anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Departamento> unidadBefore = new UnidadDeTrabajo<Departamento>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(departamento.IdDepartamento);
                }

                using (UnidadDeTrabajo<Departamento> unidad = new UnidadDeTrabajo<Departamento>(context))
                {
                    unidad.genericDAL.Remove(departamento);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla Departamento datos, borrados: \n\n"

                        + "ID: " + anterior.IdDepartamento + ", \n"
                        + "Cuartos: " + anterior.CantidadCuartos + ", \n"
                        + "Baños: " + anterior.CantidadBanios + ", \n"
                        + "Descripción: " + anterior.Descripcion + ", \n"
                        + "Id Usuario: " + anterior.IdUsuario + ", \n"
                        + "Id Condominio: " + anterior.IdCondominio);

                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Departamento> entities)
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
