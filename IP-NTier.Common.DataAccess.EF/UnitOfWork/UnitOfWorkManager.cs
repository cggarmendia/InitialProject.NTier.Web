using IP_NTier.Common.Core.Context;
using IP_NTier.Common.Core.IoC;
using IP_NTier.Common.Core.Key;
using IP_NTier.Domain.UnitOfWork;

namespace IP_NTier.Common.DataAccess.EF.UnitOfWork
{

    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        #region Members

        private ICallContext callContext;
        private object lockUoW = new object();

        #endregion Members

        #region Constructor

        public UnitOfWorkManager(ICallContext context)
        {
            callContext = context;
        }

        #endregion Constructor

        #region Methods

        public virtual IUnitOfWork GetUoW()
        {
            if (!callContext.Contains(AppKeyConst.UoW))
            {
                lock (lockUoW)
                {
                    if (!callContext.Contains(AppKeyConst.UoW))
                    {
                        callContext.Save(AppKeyConst.UoW, DependencyManager.Instance().Resolve<IUnitOfWork>());
                    }
                }
            }

            return callContext.Retrieve<IUnitOfWork>(AppKeyConst.UoW);
        }

        #endregion Methods
    }
}
