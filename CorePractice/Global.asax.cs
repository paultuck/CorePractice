using CorePractice.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CorePractice
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // drop and create the db if entity framework model changes
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFCorePracticeDBContext>());
            using (var context = new EFCorePracticeDBContext())
            {
                context.Database.Initialize(force: true);
            }
        }
    }
}
