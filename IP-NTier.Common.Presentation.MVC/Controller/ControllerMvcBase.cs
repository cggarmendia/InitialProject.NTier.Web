using IP_NTier.Common.DataAccess.EF.UnitOfWork;
using IP_NTier.Common.Core.Attribute;
using Ninject;

namespace IP_NTier.Common.Presentation.MVC.Controller
{
    using System.Web.Mvc;

    public abstract class ControllerMvcBase : Controller
    {
        #region Public Properties
        [Inject]
        public IUnitOfWorkManager uowManager { get; set; }
        #endregion Public Properties

        #region Protected Methods

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var uow = uowManager.GetUoW();

            var attributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(UnitOfWorkDoNotCommit), false);

            if (attributes.GetUpperBound(0) == -1)
                uow.Commit();

            uow.Dispose();

            base.OnActionExecuted(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var uow = uowManager.GetUoW();

            base.OnActionExecuting(filterContext);
        }

        #endregion Protected Methods
    }
}
