using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyDailyDairy.UI.Filters
{
    public class MyCookieSettingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            HttpCookie myCookie = context.HttpContext.Request.Cookies["LastURl"];

            if (myCookie == null)
            {
                myCookie = new HttpCookie("LastURl", context.HttpContext.Request.Url.AbsoluteUri);
                //newCookie.Expires = DateTime.Now.AddMinutes(3);                
                context.HttpContext.Response.Cookies.Add(myCookie);
            }
            else
            {
                myCookie.Value = context.HttpContext.Request.Url.AbsoluteUri;
            }


            // filterContext.HttpContext.Response.Cookies.Add(new HttpCookie(name, value));
        }
    }
}
