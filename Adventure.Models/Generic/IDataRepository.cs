using System.Collections.Generic;
using System.Linq;

namespace Adventure.Models.Generic
{
    public interface IDataRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
