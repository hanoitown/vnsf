using System.Web.Mvc;
using log4net;
using log4net.Core;
using Vnsf.WebHost.Infrastructure;

namespace Vnsf.WebHost.Filters
{
    public class LogFilter : IActionFilter
    {
        private readonly ILog _log;
        private readonly ICurrentUser _user;

        public LogFilter(ILog log, ICurrentUser user)
        {
            _log = log;
            _user = user;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this._log.Logger.Log(typeof(LogFilter), Level.Info, _user.User.Email, null);
        }
    }
}