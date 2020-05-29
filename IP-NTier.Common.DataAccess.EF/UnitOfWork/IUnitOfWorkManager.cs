using IP_NTier.Domain.UnitOfWork;

namespace IP_NTier.Common.DataAccess.EF.UnitOfWork
{
    public interface IUnitOfWorkManager
    {
        #region Public Methods

        IUnitOfWork GetUoW();

        #endregion Public Methods
    }
}
