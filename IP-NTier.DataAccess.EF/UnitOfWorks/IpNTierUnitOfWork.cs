using IP_NTier.Common.DataAccess.EF.UnitOfWork;
using IP_NTier.DataAccess.EF.Context;

namespace IP_NTier.DataAccess.EF.UnitOfWorks
{
    public class IpNTierUnitOfWork : UnitOfWorkBase
    {
        #region Constructor

        public IpNTierUnitOfWork()
        {
            this.context = new IpNTierContext();
        }

        #endregion
    }
}
