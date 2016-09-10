using AorangiPeak.Dto;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AorangiPeak.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterType<AdoUserRepository>().As<IRepository<User>>();
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MapperConfig.Configure();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
