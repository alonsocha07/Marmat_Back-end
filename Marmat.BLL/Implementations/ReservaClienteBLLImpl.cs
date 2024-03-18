using BackEnd.Models;
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
    public class ReservaClienteBLLImpl : IReservaClienteBLL
    {
        #region Constructor
        private IReservaClienteDAL _entityDAL;

        public ReservaClienteBLLImpl()
        {
            _entityDAL = new ReservaClienteDALImpl();
        }
        #endregion

        #region Read
        /// <summary>
        /// Obtener la lista de los Avisos 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ReservaCliente> GetAll()
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

        public List<ReservaCliente> Get()
        {
            try
            {
                return (List<ReservaCliente>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ReservaCliente Get(int idAviso)
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
        public List<ReservaCliente> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReservaCliente> Find(Expression<Func<ReservaCliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public ReservaCliente SingleOrDefault(Expression<Func<ReservaCliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public bool Add(ReservaCliente entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<ReservaCliente> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(ReservaCliente entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ReservaCliente entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ReservaCliente> entities)
        {
            throw new NotImplementedException();
        }

        public bool LoginUser(string usuario, string pass)
        {
            throw new NotImplementedException();
        }

        public bool DateCheck(DateTime fecha, int areaComun)
        {
            throw new NotImplementedException();
        }

        List<Reserva> IReservaClienteBLL.GetByName(string Name)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
