using Marmat.BLL.Contracts;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.BLL.Implementations
{
    public class ProvinciumBLLImpl : IProvinciumBLL
    {
        #region Constructor
        private IProvinciumDAL _entityDAL;

        public ProvinciumBLLImpl()
        {
            _entityDAL = new ProvinciumDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Provincium entity)
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

        public void AddRange(IEnumerable<Provincium> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        /// <summary>
        /// Obtener la lista de los Provinciums 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Provincium> GetAll()
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

        public List<Provincium> Get()
        {
            try
            {
                return (List<Provincium>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Provincium Get(int idProvincium)
        {
            try
            {
                return _entityDAL.Get(idProvincium);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del Provincium por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Provincium> GetByName(string name)
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

        public IEnumerable<Provincium> Find(Expression<Func<Provincium, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Provincium SingleOrDefault(Expression<Func<Provincium, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Provincium entity)
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
        public bool Remove(Provincium entity)
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

        public void RemoveRange(IEnumerable<Provincium> entities)
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
