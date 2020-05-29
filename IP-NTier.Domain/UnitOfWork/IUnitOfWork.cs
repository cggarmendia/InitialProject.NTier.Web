using System;
using IP_NTier.Domain.Entities;
using IP_NTier.Domain.Repository;

namespace IP_NTier.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        IRepository<T> GetRepository<T>()
            where T : class, IEntity;

        void Rollback();
    }
}
