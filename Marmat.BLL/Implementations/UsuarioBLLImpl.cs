using Marmat.BLL.Contracts;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;

namespace Marmat.BLL.Implementations
{
    public class UsuarioBLLImpl : IUsuarioBLL
    {
        #region Constructor
        private IUsuarioDAL _entityDAL;

        public UsuarioBLLImpl()
        {
            _entityDAL = new UsuarioDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Usuario entity)
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

        public void AddRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        /// <summary>
        /// Obtener la lista de los Usuarios 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> GetAll()
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

        public List<Usuario> Get()
        {
            try
            {
                return (List<Usuario>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario Get(int idUsuario)
        {
            try
            {
                return _entityDAL.Get(idUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del Usuario por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Usuario> GetByName(string name)
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

        public IEnumerable<Usuario> Find(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Usuario SingleOrDefault(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Usuario entity)
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
        public bool Remove(Usuario entity)
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

        public void RemoveRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Login
        public bool LoginUser(string usuario, string pass)
        {
            try
            {
                return _entityDAL.LoginUser(usuario, pass);
            }
            catch (Exception)
            {
                return false;
            }
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
