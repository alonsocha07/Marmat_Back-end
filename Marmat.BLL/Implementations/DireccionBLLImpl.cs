using Marmat.BLL.Contracts;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.BLL.Implementations
{
    public class DireccionBLLImpl : IDireccionBLL
    {
        #region Constructor
        private IDireccionDAL _entityDAL;

        public DireccionBLLImpl()
        {
            _entityDAL = new DireccionDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Direccion entity)
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

        public void AddRange(IEnumerable<Direccion> entities)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        #region Read
        /// <summary>
        /// Obtener la lista de los Direccions 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Direccion> GetAll()
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

        public List<Direccion> Get()
        {
            try
            {
                return (List<Direccion>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Direccion Get(int idDireccion)
        {
            try
            {
                return _entityDAL.Get(idDireccion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del Direccion por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Direccion> GetByName(string name)
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

        public IEnumerable<Direccion> Find(Expression<Func<Direccion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Direccion SingleOrDefault(Expression<Func<Direccion, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        #region Update
        public bool Update(Direccion entity)
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
        public bool Remove(Direccion entity)
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

        public void RemoveRange(IEnumerable<Direccion> entities)
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
