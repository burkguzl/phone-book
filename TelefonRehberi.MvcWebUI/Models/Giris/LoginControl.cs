using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelefonRehberi.MvcWebUI.Models.Giris
{
    public class LoginControl:ActionFilterAttribute,IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {


            try
            {
                if (HttpContext.Current.Session["AdminId"] != null)
                {
                    base.OnActionExecuting(filterContext);

                }


                else
                {
                    string url = "/Giris/Login?returnUrl=";
                    url += HttpContext.Current.Request.FilePath;


                    HttpContext.Current.Response.Redirect(url.ToString());
                }
            }
            catch (Exception)
            {

                string url = "/Giris/Login?returnUrl=";
                url += HttpContext.Current.Request.FilePath;


                HttpContext.Current.Response.Redirect(url.ToString());
            }
        }
    }
}