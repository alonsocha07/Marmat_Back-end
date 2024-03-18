using Marmat.DAL.Contracts;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class ComentarioTicketDALImpl : IComentarioTicketDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public ComentarioTicketDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public ComentarioTicketDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(ComentarioTicket ticket)
        {
            try
            {
                using (UnidadDeTrabajo<ComentarioTicket> unidad = new UnidadDeTrabajo<ComentarioTicket>(context))
                {
                    unidad.genericDAL.Add(ticket);
                    RegistrarBitacora("Comentario de ticket creado: \n\n"
                    + "Fecha: " + ticket.Fecha + ", \n"
                    + "Comentario: " + ticket.Comentario + ", \n"
                    + "Id Ticket: " + ticket.IdTicket);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<ComentarioTicket> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<ComentarioTicket> Find(Expression<Func<ComentarioTicket, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ComentarioTicket Get(int idComentarioTicket)
        {
            try
            {
                ComentarioTicket ticket;
                using (UnidadDeTrabajo<ComentarioTicket> unidad = new UnidadDeTrabajo<ComentarioTicket>(context))
                {
                    ticket = unidad.genericDAL.Get(idComentarioTicket);
                }
                return ticket;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComentarioTicket> Get()
        {
            try
            {
                IEnumerable<ComentarioTicket> ticket;
                using (UnidadDeTrabajo<ComentarioTicket> unidad = new UnidadDeTrabajo<ComentarioTicket>(context))
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

        public IEnumerable<ComentarioTicket> GetAll()
        {
            try
            {
                IEnumerable<ComentarioTicket> ticket;
                using (UnidadDeTrabajo<ComentarioTicket> unidad = new UnidadDeTrabajo<ComentarioTicket>(context))
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
        List<ComentarioTicket> IComentarioTicketDAL.GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<ComentarioTicket> GetByName(string Name)
        {
            try
            {
                List<ComentarioTicket> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.ComentarioTickets
                             where x.Comentario.Contains(Name)
                             select x).ToList();

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ComentarioTicket SingleOrDefault(Expression<Func<ComentarioTicket, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(ComentarioTicket ticket)
        {
            ComentarioTicket anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<ComentarioTicket> unidadBefore = new UnidadDeTrabajo<ComentarioTicket>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(ticket.IdComentarioTicket);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<ComentarioTicket> unidad = new UnidadDeTrabajo<ComentarioTicket>(context))
                {
                    unidad.genericDAL.Update(ticket);
                    result = unidad.Complete();

                    RegistrarBitacora("Tabla: Comentario ticket modificada, los datos anteriores son: \n\n"
                        + "ID: " + anterior.IdComentarioTicket + ", \n"
                        + "Fecha: " + anterior.Fecha + ", \n"
                        + "Comentario: " + anterior.Comentario + ", \n"
                        + "Id Ticket: " + anterior.IdTicket + ", \n"

                        + ", fueron cambiados por: \n\n"

                        + "ID: " + ticket.IdComentarioTicket + ", \n"
                        + "Fecha: " + ticket.Fecha + ", \n"
                        + "Comentario: " + ticket.Comentario + ", \n"
                        + "Id Ticket: " + ticket.IdTicket);
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
        public bool Remove(ComentarioTicket ticket)
        {
            ComentarioTicket anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<ComentarioTicket> unidadBefore = new UnidadDeTrabajo<ComentarioTicket>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(ticket.IdComentarioTicket);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<ComentarioTicket> unidad = new UnidadDeTrabajo<ComentarioTicket>(context))
                {
                    unidad.genericDAL.Remove(ticket);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla Comentario ticket, datos borrados: \n\n"

                        + "ID: " + anterior.IdComentarioTicket + ", \n"
                        + "Fecha: " + anterior.Fecha + ", \n"
                        + "Comentario: " + anterior.Comentario + ", \n"
                        + "Id Ticket: " + anterior.IdTicket);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<ComentarioTicket> entities)
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
