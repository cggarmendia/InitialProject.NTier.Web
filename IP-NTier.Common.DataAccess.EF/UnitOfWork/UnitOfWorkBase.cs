﻿using System;
using System.Collections.Generic;
using IP_NTier.Common.Core.Context;
using IP_NTier.Common.Core.IoC;
using IP_NTier.Common.Core.Key;
using IP_NTier.Common.DataAccess.EF.Context;
using IP_NTier.Domain.Entities;
using IP_NTier.Domain.Repository;
using IP_NTier.Domain.UnitOfWork;
using IP_NTier.Common.DataAccess.EF.Repository;

namespace IP_NTier.Common.DataAccess.EF.UnitOfWork
{
    public abstract class UnitOfWorkBase : IUnitOfWork, IDisposable
    {
        #region Members

        private bool disposed = false;
        private object lockRepo = new object();
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        #endregion Members

        #region Properties

        public DBContextBase context { get; set; }

        #endregion Properties

        #region Constructor

        public UnitOfWorkBase()
        {
        }

        #endregion Constructor

        #region Public Methods

        public void Commit()
        {
            context.Commit();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<T> GetRepository<T>()
            where T : class, IEntity
        {
            if (!repositories.ContainsKey(typeof(T)))
            {
                lock (lockRepo)
                {
                    if (!repositories.ContainsKey(typeof(T)))
                        repositories.Add(typeof(T), new Repository<T>(context));
                }
            }
            return (IRepository<T>)repositories[typeof(T)];
        }

        public virtual void Rollback()
        {
            context.Rollback();
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ICallContext callContext = DependencyManager.Instance().Resolve<ICallContext>();
                    callContext.Remove(AppKeyConst.UoW);
                    context.Dispose();
                    context = null;
                }
            }
            this.disposed = true;
        }

        #endregion Protected Methods
    }
}
