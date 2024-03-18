using Marmat.BLL.Contracts;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.BLL.Implementations
{
    public class DistritoBLLImpl : IDistritoBLL
    {
        #region Constructor
        private IDistritoDAL _entityDAL;

        public DistritoBLLImpl()
        {
            _entityDAL = new DistritoDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Distrito entity)
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

        public void AddRange(IEnumerable<Distrito> entities)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        #region Read
        /// <summary>
        /// Obtener la lista de los Distritos 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Distrito> GetAll()
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

        public List<Distrito> Get()
        {
            try
            {
                return (List<Distrito>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Distrito Get(int idDistrito)
        {
            try
            {
                return _entityDAL.Get(idDistrito);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del Distrito por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Distrito> GetByName(string name)
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

        public IEnumerable<Distrito> Find(Expression<Func<Distrito, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Distrito SingleOrDefault(Expression<Func<Distrito, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        #region Update
        public bool Update(Distrito entity)
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
        public bool Remove(Distrito entity)
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

        public void RemoveRange(IEnumerable<Distrito> entities)
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
