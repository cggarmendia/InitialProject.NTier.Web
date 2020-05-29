using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using IP_NTier.Common.Core.Config;
using IP_NTier.Common.Core.IoC;
using IP_NTier.Common.IoC;
using IP_NTier.Presentation.MVC;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Syntax;
using Ninject.Web.Common;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace IP_NTier.Presentation.MVC
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void RegisterNinject(HttpConfiguration configuration)
        {
            configuration.DependencyResolver = new NinjectDependencyResolver(bootstrapper.Kernel);
        }

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            INinjectModule[] configModules = new INinjectModule[] { new IoCConfigModule() };
            AppConfig.InitIoC(configModules);

            var kernel = DependencyManager.Instance().GetKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }        
    }

    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }
    }

    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            Contract.Assert(resolver != null);
            this.resolver = resolver;
        }

        public void Dispose()
        {
            var disposable = resolver as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
            resolver = null;
        }

        public object GetService(Type serviceType)
        {
            if (resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has already been disposed");
            }
            return resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has already been disposed");
            }
            return resolver.GetAll(serviceType);
        }
    }

}
