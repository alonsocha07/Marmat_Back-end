using Marmat.BLL.Contracts;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.BLL.Implementations
{
    public class ComentarioTicketBLLImpl : IComentarioTicketBLL
    {
        #region Constructor
        private IComentarioTicketDAL _entityDAL;

        public ComentarioTicketBLLImpl()
        {
            _entityDAL = new ComentarioTicketDALImpl();
        }
        #endregion

        #region Create
        public bool Add(ComentarioTicket entity)
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

        public void AddRange(IEnumerable<ComentarioTicket> entities)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        #region Read
        /// <summary>
        /// Obtener la lista de los ComentarioTickets 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ComentarioTicket> GetAll()
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

        public List<ComentarioTicket> Get()
        {
            try
            {
                return (List<ComentarioTicket>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ComentarioTicket Get(int idComentarioTicket)
        {
            try
            {
                return _entityDAL.Get(idComentarioTicket);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del ComentarioTicket por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<ComentarioTicket> GetByName(string name)
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

        public IEnumerable<ComentarioTicket> Find(Expression<Func<ComentarioTicket, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ComentarioTicket SingleOrDefault(Expression<Func<ComentarioTicket, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(ComentarioTicket entity)
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
        public bool Remove(ComentarioTicket entity)
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

        public void RemoveRange(IEnumerable<ComentarioTicket> entities)
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
