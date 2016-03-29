using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDailyDairy.UI.Controllers
{
    public class BaseController : Controller
    {       
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            HttpCookie myCookie = Request.Cookies["URL"];

            if (myCookie == null)
            {
                myCookie = new HttpCookie("URL", context.HttpContext.Request.Url.AbsoluteUri);
                //newCookie.Expires = DateTime.Now.AddMinutes(3);                
                context.HttpContext.Response.Cookies.Add(myCookie);
            }
            else
            {
                myCookie.Value = context.HttpContext.Request.Url.AbsoluteUri;
            }

            base.OnActionExecuting(context);
        }
    }
}