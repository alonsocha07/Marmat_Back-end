#region Using
using Marmat.DAL.Contracts;
using Marmat.DML;
using System.Linq.Expressions;

#endregion

namespace Marmat.DAL.Implementations
{
    public class AvisoDALImpl : IAvisoDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public AvisoDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public AvisoDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Aviso entity)
        {
            try
            {
                using (UnidadDeTrabajo<Aviso> unidad = new UnidadDeTrabajo<Aviso>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }
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
        public IEnumerable<Aviso> Find(Expression<Func<Aviso, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Aviso> Get()
        {
            try
            {
                IEnumerable<Aviso> entity;
                using (UnidadDeTrabajo<Aviso> unidad = new UnidadDeTrabajo<Aviso>(context))
                {
                    entity = unidad.genericDAL.GetAll();
                }
                return entity.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Aviso> GetAll()
        {
            try
            {
                IEnumerable<Aviso> entity;
                using (UnidadDeTrabajo<Aviso> unidad = new UnidadDeTrabajo<Aviso>(context))
                {
                    entity = unidad.genericDAL.GetAll();
                }
                return entity;
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
                Aviso entity;
                using (UnidadDeTrabajo<Aviso> unidad = new UnidadDeTrabajo<Aviso>(context))
                {
                    entity = unidad.genericDAL.Get(idAviso);
                }
                return entity;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Aviso> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Aviso SingleOrDefault(Expression<Func<Aviso, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Aviso aviso)
        {

            try
            {
                using (UnidadDeTrabajo<Aviso> unidad = new UnidadDeTrabajo<Aviso>(context))
                {
                    unidad.genericDAL.Update(aviso);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Delete
        public bool Remove(Aviso entity)
        {
            try
            {
                using (UnidadDeTrabajo<Aviso> unidad = new UnidadDeTrabajo<Aviso>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RemoveRange(IEnumerable<Aviso> entities)
        {
            throw new NotImplementedException();
        }
        #endregion
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
    }
}
