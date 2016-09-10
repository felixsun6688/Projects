using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Domain.Core.Repository;
using AorangiPeak.Infrastructure.ADORepository;
using Autofac;

namespace AorangiPeak.Infrastructure
{
    public class AutofacContainer
    {
        private AutofacContainer() { }

        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AdoUserRepository>().As<IRepository<User>>();
            builder.RegisterType<AdoRoleRepository>().As<IRepository<Role>>();
            builder.RegisterType<AdoMenuRepository>().As<IRepository<Menu>>();
            builder.RegisterType<AdoFunctionRepository>().As<IRepository<Function>>();
            builder.RegisterType<AdoTableBookingRepository>().As<IRepository<TableBooking>>();
            builder.RegisterType<AdoTableBookingTimeRepository>().As<IRepository<TableBookingTime>>();
            builder.RegisterType<AdoTableBookingAdultsRepository>().As<IRepository<TableBookingAdults>>();
            builder.RegisterType<AdoTableBookingChildrenRepository>().As<IRepository<TableBookingChildren>>();

            return builder.Build();
        }
    }
}
