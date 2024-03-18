using Common.Cache;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class ReservaDALImpl : IReservaDAL
    {
        #region Constructor
        Condominios_MarmatContext context;
        UserDML _usuarioLoging;

        public ReservaDALImpl()
        {
            _usuarioLoging = new UserDML();
            context = new Condominios_MarmatContext();
        }

        public ReservaDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Reserva reserva)
        {
            try
            {
                using (UnidadDeTrabajo<Reserva> unidad = new UnidadDeTrabajo<Reserva>(context))
                {
                    unidad.genericDAL.Add(reserva);
                    RegistrarBitacora("Reserva creada: \n\n"
                    + "Fecha: " + reserva.FechaReserva);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Reserva> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Reserva> Find(Expression<Func<Reserva, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> Get()
        {
            try
            {
                IEnumerable<Reserva> entity;
                using (UnidadDeTrabajo<Reserva> unidad = new UnidadDeTrabajo<Reserva>(context))
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

        public IEnumerable<Reserva> GetAll()
        {
            try
            {
                IEnumerable<Reserva> entity;
                using (UnidadDeTrabajo<Reserva> unidad = new UnidadDeTrabajo<Reserva>(context))
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

        public Reserva Get(int idReserva)
        {
            try
            {
                Reserva entity;
                using (UnidadDeTrabajo<Reserva> unidad = new UnidadDeTrabajo<Reserva>(context))
                {
                    entity = unidad.genericDAL.Get(idReserva);
                }
                return entity;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Reserva> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Reserva SingleOrDefault(Expression<Func<Reserva, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Reserva reserva)
        {
            Reserva anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Reserva> unidadBefore = new UnidadDeTrabajo<Reserva>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(reserva.IdReserva);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Reserva> unidad = new UnidadDeTrabajo<Reserva>(context))
                {
                    unidad.genericDAL.Update(reserva);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla: Reserva modificada, los datos anteriores son: \n\n"
                        + "ID: " + anterior.IdReserva + ", \n"
                        + "fecha" + anterior.FechaReserva + ", \n"

                        + ", fueron cambiados por: \n\n"

                        + "ID: " + reserva.IdReserva + ", \n"
                        + "fecha: " + reserva.FechaReserva + ", \n");
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
        public bool Remove(Reserva reserva)
        {
            Reserva anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Reserva> unidadBefore = new UnidadDeTrabajo<Reserva>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(reserva.IdReserva);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Reserva> unidad = new UnidadDeTrabajo<Reserva>(context))
                {
                    unidad.genericDAL.Remove(reserva);
                    result = unidad.Complete();

                    RegistrarBitacora("Tabla Reserva, datos borrados: \n\n"

                       + "ID: " + anterior.IdReserva + ", \n"
                       + "Nombre: " + anterior.FechaReserva + ", \n");
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Reserva> entities)
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

        public bool DateCheck(DateTime fecha, int areaComun)
        {
            using (var conexion = _usuarioLoging.GetConnection())
            {
                conexion.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "select *from Reserva where FECHA_RESERVA=@fecha and ID_AREACOMUN=@areaComun";
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@areaComun", areaComun);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }           
        }
        #endregion
    }
}
