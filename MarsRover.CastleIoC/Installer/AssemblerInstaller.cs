using Business.Assembler;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MarsRover.CastleIoC.Installer
{
    public class AssemblerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IInputModelAssembler>().ImplementedBy<InputModelAssembler>().LifeStyle.Transient);
        }
    }
}
