
using Marmat.BLL.Contracts;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.BLL.Implementations
{
    public class EstadoBLLImpl : IEstadoBLL
    {
        #region Constructor
        private IEstadoDAL _entityDAL;

        public EstadoBLLImpl()
        {
            _entityDAL = new EstadoDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Estado entity)
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

        public void AddRange(IEnumerable<Estado> entities)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        #region Read
        /// <summary>
        /// Obtener la lista de los Estados 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Estado> GetAll()
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

        public List<Estado> Get()
        {
            try
            {
                return (List<Estado>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Estado Get(int idEstado)
        {
            try
            {
                return _entityDAL.Get(idEstado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del Estado por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Estado> GetByName(string name)
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

        public IEnumerable<Estado> Find(Expression<Func<Estado, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Estado SingleOrDefault(Expression<Func<Estado, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Estado entity)
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
        public bool Remove(Estado entity)
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

        public void RemoveRange(IEnumerable<Estado> entities)
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
