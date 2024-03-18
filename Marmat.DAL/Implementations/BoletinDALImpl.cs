#region Using
using Marmat.DAL.Contracts;
using Marmat.DML;
using System.Linq.Expressions;

#endregion

namespace Marmat.DAL.Implementations
{
    public class BoletinDALImpl : IBoletinDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public BoletinDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public BoletinDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Boletin entity)
        {
            try
            {
                using (UnidadDeTrabajo<Boletin> unidad = new UnidadDeTrabajo<Boletin>(context))
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

        public void AddRange(IEnumerable<Boletin> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Boletin> Find(Expression<Func<Boletin, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Boletin> Get()
        {
            try
            {
                IEnumerable<Boletin> entity;
                using (UnidadDeTrabajo<Boletin> unidad = new UnidadDeTrabajo<Boletin>(context))
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

        public IEnumerable<Boletin> GetAll()
        {
            try
            {
                IEnumerable<Boletin> entity;
                using (UnidadDeTrabajo<Boletin> unidad = new UnidadDeTrabajo<Boletin>(context))
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

        public Boletin Get(int idAviso)
        {
            try
            {
                Boletin entity;
                using (UnidadDeTrabajo<Boletin> unidad = new UnidadDeTrabajo<Boletin>(context))
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

        public List<Boletin> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Boletin SingleOrDefault(Expression<Func<Boletin, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Boletin boletin)
        {

            try
            {
                using (UnidadDeTrabajo<Boletin> unidad = new UnidadDeTrabajo<Boletin>(context))
                {
                    unidad.genericDAL.Update(boletin);
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
        public bool Remove(Boletin entity)
        {
            try
            {
                using (UnidadDeTrabajo<Boletin> unidad = new UnidadDeTrabajo<Boletin>(context))
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

        public void RemoveRange(IEnumerable<Boletin> entities)
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
