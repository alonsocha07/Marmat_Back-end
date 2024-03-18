#region Using
using Marmat.BLL.Contracts;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using System.Linq.Expressions;
#endregion

namespace Marmat.BLL.Implementations
{
    public class BitacoraBLLImpl : IBitacoraBLL
    {
        #region Constructor
        private IBitacoraDAL _entityDAL;

        public BitacoraBLLImpl()
        {
            _entityDAL = new BitacoraDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Bitacora entity)
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

        public void AddRange(IEnumerable<Bitacora> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        /// <summary>
        /// Obtener la lista de los Bitacoras 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Bitacora> GetAll()
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

        public List<Bitacora> Get()
        {
            try
            {
                return (List<Bitacora>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Bitacora Get(int idBitacora)
        {
            try
            {
                return _entityDAL.Get(idBitacora);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la informacion del Bitacora por Nombre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Bitacora> GetByName(string name)
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

        public IEnumerable<Bitacora> Find(Expression<Func<Bitacora, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public Bitacora SingleOrDefault(Expression<Func<Bitacora, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Bitacora entity)
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
        public bool Remove(Bitacora entity)
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

        public void RemoveRange(IEnumerable<Bitacora> entities)
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
