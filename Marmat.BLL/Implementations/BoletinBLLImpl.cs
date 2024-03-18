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
    public class BoletinBLLImpl : IBoletinBLL
    {
        #region Constructor
        private IBoletinDAL _entityDAL;

        public BoletinBLLImpl()
        {
            _entityDAL = new BoletinDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Boletin entity)
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

        public void AddRange(IEnumerable<Boletin> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        /// <summary>
        /// Obtener la lista de los Avisos 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Boletin> GetAll()
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

        public List<Boletin> Get()
        {
            try
            {
                return (List<Boletin>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Boletin Get(int idAviso)
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
        /// Obtiene la informacion del Aviso por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Boletin> GetByName(string name)
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

        public IEnumerable<Boletin> Find(Expression<Func<Boletin, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public Boletin SingleOrDefault(Expression<Func<Boletin, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Boletin entity)
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
        public bool Remove(Boletin entity)
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

        public void RemoveRange(IEnumerable<Boletin> entities)
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
