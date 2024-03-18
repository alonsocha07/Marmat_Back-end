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
    public class AreaComunBLLImpl : IAreaComunBLL
    {
        #region Constructor
        private IAreaComunDAL _entityDAL;

        public AreaComunBLLImpl()
        {
            _entityDAL = new AreacomunDALImpl();
        }
        #endregion

        #region Create
        public bool Add(Areacomun entity)
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

        public void AddRange(IEnumerable<Areacomun> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        /// <summary>
        /// Obtener la lista de los Avisos 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Areacomun> GetAll()
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

        public List<Areacomun> Get()
        {
            try
            {
                return (List<Areacomun>)_entityDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Areacomun Get(int idAreaComun)
        {
            try
            {
                return _entityDAL.Get(idAreaComun);
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
        public List<Areacomun> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Areacomun> Find(Expression<Func<Areacomun, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public Areacomun SingleOrDefault(Expression<Func<Areacomun, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Areacomun entity)
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
        public bool Remove(Areacomun entity)
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

        public void RemoveRange(IEnumerable<Areacomun> entities)
        {
            throw new NotImplementedException();
        }

        public bool LoginUser(string usuario, string pass)
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
