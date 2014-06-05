using PTO.Core.Interfaces;
using PTO.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTO.Web.Filters
{
    public class UnitOfWorkAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = DependencyResolver.Current.GetService<ISession<AppContext>>();
            session.Complete();
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}