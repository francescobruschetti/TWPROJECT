using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Threading;

namespace TWPROJECT_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AcquireRequestSate(object sender, EventArgs e)
        {
            var lang = "it"; // cambiandolo con "en" prende usa il ile GanttLanguage.en (i seguenti 2 campi vanno modificati anche nel file Global.asax.cs)
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
        }
    }
}
