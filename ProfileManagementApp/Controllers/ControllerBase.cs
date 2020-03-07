using System.Web.Mvc;
using System.Web.Routing;

namespace ProfileManagementApp.Controllers
{
    [HandleError]
    public class ControllerBase : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        #region Set Error And Success Messages
        protected void SetSuccessMessage(string message, params string[] args)
        {
            ViewBag.SuccessMessage = string.Format(message, args);
            TempData["SuccessMessage"] = ViewBag.SuccessMessage;
        }

        protected void SetErrorMessage(string message, params string[] args)
        {
            ViewBag.ErrorMessage = string.Format(message, args);
            TempData["ErrorMessage"] = ViewBag.ErrorMessage;
        }
        #endregion
    }
}