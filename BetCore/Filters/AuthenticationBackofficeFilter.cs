using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCore.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthenticationBackofficeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ((Controller)context.Controller).TempData["REDIRECT_BO"] =
                context.HttpContext.Request.Path.Value;
            //base.OnActionExecuting(context);
            if (string.IsNullOrWhiteSpace(context.HttpContext.Session.GetString("USER_BO")))
            {
                context.Result = new RedirectToActionResult("Login", "AuthenticationBackoffice", new  { area = "Backoffice" });
            }
        }
    }
}
