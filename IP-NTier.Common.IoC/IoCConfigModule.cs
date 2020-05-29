using IP_NTier.Business.DomainServices.Modules.Security;
using IP_NTier.Common.Core.Context;
using IP_NTier.Common.DataAccess.EF.UnitOfWork;
using IP_NTier.Common.InitializeDatabase;
using IP_NTier.Common.Presentation.MVC.Context;
using IP_NTier.DataAccess.EF.UnitOfWorks;
using IP_NTier.Domain.UnitOfWork;
using Ninject.Modules;

namespace IP_NTier.Common.IoC
{
    public class IoCConfigModule : NinjectModule
    {
        #region Public Methods

        public override void Load()
        {
            // Infraestructure
            Bind<IUnitOfWork>().To<IpNTierUnitOfWork>();
            Bind<IUnitOfWorkManager>().To<UnitOfWorkManager>().InSingletonScope();

            // Call Context
            Bind<ICallContext>().To<WebCallContext>().InSingletonScope();

            // DomainServices
            Bind<IUserDomainServices>().To<UserDomainServices>().InSingletonScope();
            Bind<IRoleDomainServices>().To<RoleDomainServices>().InSingletonScope();


            // InitializeDatabase
            Bind<IIpNTierInitializer>().To<IpNTierInitializer>().InSingletonScope();
            Bind<IIpNTierSecurityInitializer>().To<IpNTierSecurityInitializer>().InSingletonScope();
        }

        #endregion Public Methods
    }
}
