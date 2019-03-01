using Business;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MarsRover.CastleIoC.Installer;

namespace MarsRover.CastleIoC.DependencyResolver
{
    public class StartupCastle
    {
        public static IWindsorContainer Container;
        public static void Init()
        {
            Container = new WindsorContainer();

            Container.AddFacility<TypedFactoryFacility>(); 

            Container.Register(Component.For<ITypedFactoryComponentSelector>().ImplementedBy<CommandServiceTypedFactoryComponentSelector>());

            Container.Register(Component.For<IServiceFactory>().AsFactory(c => c.SelectedWith(new CommandServiceTypedFactoryComponentSelector())));

            Container.Register(Component.For<ApplicationConfiguration>().LifeStyle.Singleton);

            Container.Install(new OperationServiceInstaller());

            Container.Install(new AssemblerInstaller()); 
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

    }
}
