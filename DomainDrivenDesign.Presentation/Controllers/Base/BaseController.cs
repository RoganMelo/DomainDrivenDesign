using DomainDrivenDesign.Infra.Data.Context.Interfaces;
using System.Web.Mvc;

namespace DomainDrivenDesign.Presentation.Controllers
{
    public class BaseController : Controller
    {
        private IUnitOfWork unitOfWork;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid && filterContext.HttpContext.Error == null)
                unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();

            if (!filterContext.IsChildAction)
                unitOfWork.BeginTransaction();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction && filterContext.Controller.ViewData.ModelState.IsValid && filterContext.HttpContext.Error == null && unitOfWork != null)
                unitOfWork.Commit();
        }
    }
}