using Marmat.BLL.Contracts;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.BLL.Implementations
{
    public class TicketBLLImpl : ITickectBLL
    {
        #region Constructor
        private ITicketDAL _entityDAL;

        public TicketBLLImpl()
        {
            _entityDAL = new TicketDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Ticket entity)
        {
            try
            {
                return _entityDAL.Add(entity);
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
        /// <summary>
        /// Obtener la lista de los Tickets 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Ticket> GetAll()
        {
            try
            {
                return _entityDAL.GetAll();
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
                return (List<Ticket>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Ticket Get(int idTicket)
        {
            try
            {
                return _entityDAL.Get(idTicket);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del Ticket por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Ticket> GetByName(string name)
        {
            try
            {
                return _entityDAL.GetByName(name);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Ticket> Find(Expression<Func<Ticket, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Ticket SingleOrDefault(Expression<Func<Ticket, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Ticket entity)
        {
            bool result = false;

            try
            {
                _entityDAL.Update(entity);
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }

        #endregion

        #region Delete
        public bool Remove(Ticket entity)
        {
            bool result = false;
            try
            {
                _entityDAL.Remove(entity);
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
