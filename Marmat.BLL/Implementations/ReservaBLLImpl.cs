using Marmat.BLL.Contracts;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Marmat.BLL.Implementations
{
    public class ReservaBLLImpl : IReservalBLL
    {
        #region Constructor
        private IReservaDAL _entityDAL;

        public ReservaBLLImpl()
        {
            _entityDAL = new ReservaDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Reserva entity)
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

        public void AddRange(IEnumerable<Reserva> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        /// <summary>
        /// Obtener la lista de los Avisos 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Reserva> GetAll()
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

        public List<Reserva> Get()
        {
            try
            {
                return (List<Reserva>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Reserva Get(int idAviso)
        {
            try
            {
                return _entityDAL.Get(idAviso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del Reserva por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Reserva> GetByName(string name)
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

        public IEnumerable<Reserva> Find(Expression<Func<Reserva, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public Reserva SingleOrDefault(Expression<Func<Reserva, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Reserva entity)
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
        public bool Remove(Reserva entity)
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

        public void RemoveRange(IEnumerable<Reserva> entities)
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
            try
            {
                return _entityDAL.DateCheck(fecha, areaComun);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
