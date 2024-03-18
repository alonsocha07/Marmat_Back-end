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
    public class AvisoBLLImpl : IAvisoBLL
    {
        #region Constructor
        private IAvisoDAL _entityDAL;

        public AvisoBLLImpl()
        {
            _entityDAL = new AvisoDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Aviso entity)
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

        public void AddRange(IEnumerable<Aviso> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        /// <summary>
        /// Obtener la lista de los Avisos 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Aviso> GetAll()
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

        public List<Aviso> Get()
        {
            try
            {
                return (List<Aviso>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Aviso Get(int idAviso)
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
        public List<Aviso> GetByName(string name)
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

        public IEnumerable<Aviso> Find(Expression<Func<Aviso, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public Aviso SingleOrDefault(Expression<Func<Aviso, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Aviso entity)
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
        public bool Remove(Aviso entity)
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

        public void RemoveRange(IEnumerable<Aviso> entities)
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
