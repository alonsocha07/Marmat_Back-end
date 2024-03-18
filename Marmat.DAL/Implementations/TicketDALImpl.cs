using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class TicketDALImpl : ITicketDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public TicketDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public TicketDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Ticket ticket)
        {
            try
            {
                using (UnidadDeTrabajo<Ticket> unidad = new UnidadDeTrabajo<Ticket>(context))
                {
                    unidad.genericDAL.Add(ticket);
                    RegistrarBitacora("Ticket creado: \n\n"
                    + "Descripción: " + ticket.Descripcion + ", \n"
                    + "Id Estado: " + ticket.IdEstado + ", \n"
                    + "Id Usuario: " + ticket.IdUsuario + ", \n"
                    + "Id Departamento: " + ticket.IdDepartamento);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Ticket> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Ticket> Find(Expression<Func<Ticket, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Ticket Get(int idTicket)
        {
            try
            {
                Ticket ticket;
                using (UnidadDeTrabajo<Ticket> unidad = new UnidadDeTrabajo<Ticket>(context))
                {
                    ticket = unidad.genericDAL.Get(idTicket);
                }
                return ticket;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Ticket> Get()
        {
            try
            {
                IEnumerable<Ticket> ticket;
                using (UnidadDeTrabajo<Ticket> unidad = new UnidadDeTrabajo<Ticket>(context))
                {
                    ticket = unidad.genericDAL.GetAll();
                }
                return ticket.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Ticket> GetAll()
        {
            try
            {
                IEnumerable<Ticket> ticket;
                using (UnidadDeTrabajo<Ticket> unidad = new UnidadDeTrabajo<Ticket>(context))
                {
                    ticket = unidad.genericDAL.GetAll();
                }
                return ticket;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Ticket> GetByName(string Name)
        {
            try
            {
                List<Ticket> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.Tickets
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

        public Ticket SingleOrDefault(Expression<Func<Ticket, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Ticket ticket)
        {
            Ticket anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Ticket> unidadBefore = new UnidadDeTrabajo<Ticket>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(ticket.IdTicket);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Ticket> unidad = new UnidadDeTrabajo<Ticket>(context))
                {
                    unidad.genericDAL.Update(ticket);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla: Ticket modificada, los datos anteriores son: \n\n"
                       + "ID: " + anterior.IdTicket + ", \n"
                       + "Descripción: " + anterior.Descripcion + ", \n"
                       + "Id Estado: " + anterior.IdEstado + ", \n"
                       + "Id Usuario: " + anterior.IdUsuario + ", \n"
                       + "Id Departamento: " + anterior.IdDepartamento + ", \n"

                       + ", fueron cambiados por: \n\n"

                       + "ID: " + ticket.IdTicket + ", \n"
                       + "Descripción: " + ticket.Descripcion + ", \n"
                       + "Id Estado: " + ticket.IdEstado + ", \n"
                       + "Id Usuario: " + ticket.IdUsuario + ", \n"
                       + "Id Departamento: " + ticket.IdDepartamento + ", \n");
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
        public bool Remove(Ticket ticket)
        {
            Ticket anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Ticket> unidadBedore = new UnidadDeTrabajo<Ticket>(context))
                {
                    anterior = unidadBedore.genericDAL.Get(ticket.IdTicket);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Ticket> unidad = new UnidadDeTrabajo<Ticket>(context))
                {
                    unidad.genericDAL.Remove(ticket);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla ticket, datos borrados: \n\n"

                     + "ID: " + anterior.IdTicket + ", \n"
                       + "Descripción: " + anterior.Descripcion + ", \n"
                       + "Id Estado: " + anterior.IdEstado + ", \n"
                       + "Id Usuario: " + anterior.IdUsuario + ", \n"
                       + "Id Departamento: " + anterior.IdDepartamento + ", \n");
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Ticket> entities)
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
