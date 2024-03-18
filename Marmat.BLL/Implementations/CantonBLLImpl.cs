using Marmat.BLL.Contracts;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.BLL.Implementations
{
    public class CantonBLLImpl : ICantonBLL
    {
        #region Constructor
        private ICantonDAL _entityDAL;

        public CantonBLLImpl()
        {
            _entityDAL = new CantonDALImpl();
        }
        #endregion
        
        #region Create
        public bool Add(Canton entity)
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

        public void AddRange(IEnumerable<Canton> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        /// <summary>
        /// Obtener la lista de los Cantons 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Canton> GetAll()
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

        public List<Canton> Get()
        {
            try
            {
                return (List<Canton>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Canton Get(int idCanton)
        {
            try
            {
                return _entityDAL.Get(idCanton);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del Canton por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Canton> GetByName(string name)
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

        public IEnumerable<Canton> Find(Expression<Func<Canton, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Canton SingleOrDefault(Expression<Func<Canton, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Canton entity)
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
        public bool Remove(Canton entity)
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

        public void RemoveRange(IEnumerable<Canton> entities)
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
