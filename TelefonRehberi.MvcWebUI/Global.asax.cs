using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TelefonRehberi.MvcWebUI.NinjectController;

namespace TelefonRehberi.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //ninject
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
