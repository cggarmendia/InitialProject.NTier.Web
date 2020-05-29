using IP_NTier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IP_NTier.Common.Core.DomainServices
{
    public interface IDomainServiceBase<TEntity>
           where TEntity : IEntity
    {
        IQueryable<TEntity> AsQueryable();

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetByFilters(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null);

        List<TEntity> GetAll();

        TEntity GetByPKs(params object[] keyValues);

        void Add(TEntity entity);

        void Update(TEntity entity);
    }
}
