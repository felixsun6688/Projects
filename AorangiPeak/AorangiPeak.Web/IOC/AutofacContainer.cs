using AorangiPeak.Service;
using AorangiPeak.Service.ServiceInterface;
using Autofac;

namespace AorangiPeak.Web.IOC
{
    public class AutofacContainer
    {
        private AutofacContainer() { }

        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.RegisterType<FunctionService>().As<IFunctionService>();
            builder.RegisterType<TableBookingService>().As<ITableBookingService>();

            return builder.Build();
        }
    }
}