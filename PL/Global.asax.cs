using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BLL.Infrastructure;
using Ninject;
using Ninject.Modules;
using PL.Infastructures;
using PL.Util;

namespace PL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule orderModule = new CarModule();
            NinjectModule serviceModule = new ServiceModule("name=DefaultConnection");
            var kernel = new StandardKernel(orderModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
