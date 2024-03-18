using Marmat.BLL.Contracts;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.BLL.Implementations
{
    public class CondominioBLLImpl : ICondominioBLL
    {
        #region Constructor
        private ICondominioDAL _entityDAL;

        public CondominioBLLImpl()
        {
            _entityDAL = new CondominioDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Condominio entity)
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

        public void AddRange(IEnumerable<Condominio> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        /// <summary>
        /// Obtener la lista de los condominios 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Condominio> GetAll()
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

        public List<Condominio> Get()
        {
            try
            {
                return (List<Condominio>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Condominio Get(int idCondominio)
        {
            try
            {
                return _entityDAL.Get(idCondominio);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del condominio por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Condominio> GetByName(string name)
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

        public List<Condominio> GetByProvincia(string provinciaid)
        {
            try
            {
                return _entityDAL.GetByProvincia(provinciaid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetDireccion(int direccionId)
        {
            try
            {
                return _entityDAL.GetDireccion(direccionId);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IEnumerable<Condominio> Find(Expression<Func<Condominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Condominio SingleOrDefault(Expression<Func<Condominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Condominio entity)
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
        public bool Remove(Condominio entity)
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

        public void RemoveRange(IEnumerable<Condominio> entities)
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
