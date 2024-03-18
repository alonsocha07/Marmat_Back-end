using Marmat.BLL.Contracts;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.BLL.Implementations
{
    public class DepartamentoBLLImpl : IDepartamentoBLL
    {
        #region Constructor
        private IDepartamentoDAL _entityDAL;

        public DepartamentoBLLImpl()
        {
            _entityDAL = new DepartamentoDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Departamento entity)
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

        public void AddRange(IEnumerable<Departamento> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        /// <summary>
        /// Obtener la lista de los Departamentos 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Departamento> GetAll()
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

        public List<Departamento> Get()
        {
            try
            {
                return (List<Departamento>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Departamento Get(int idDepartamento)
        {
            try
            {
                return _entityDAL.Get(idDepartamento);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del Departamento por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Departamento> GetByName(string name)
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

        public List<Departamento> GetByIdCondominio(int idCondominio)
        {
            try
            {
                return _entityDAL.GetByIdCondominio(idCondominio);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Departamento> Find(Expression<Func<Departamento, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Departamento SingleOrDefault(Expression<Func<Departamento, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Departamento entity)
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
        public bool Remove(Departamento entity)
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

        public void RemoveRange(IEnumerable<Departamento> entities)
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
