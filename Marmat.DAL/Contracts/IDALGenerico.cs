using System.Linq.Expressions;

namespace Marmat.DAL.Contracts
{
    //I nomenclatura, es porque es una interfaz, esta es publica y puede tener cualquier cosa <TEntity> pero le decimos que TEntity tiene que ser una clase
    public interface IDALGenerico<TEntity> where TEntity : class 
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //This method was not in the videos, but I thought it would be useful to add.
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        bool Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        bool Update(TEntity entity);
        bool Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        bool LoginUser(string usuario, string pass);

        public bool DateCheck(DateTime fecha , int areaComun);
    }
}
