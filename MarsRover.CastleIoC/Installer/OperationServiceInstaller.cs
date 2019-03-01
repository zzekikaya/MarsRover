using System;
using System.Collections.Generic;
using System.Text;
using Business.Interface;
using Business.OperationService;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MarsRover.CastleIoC.Installer
{
    class OperationServiceInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IInputService>().ImplementedBy<InputService>().LifeStyle.Singleton);

            container.Register(Component.For<IRoverService>().ImplementedBy<RoverService>().LifeStyle.Transient);

            container.Register(Component.For<IPlateauService>().ImplementedBy<PlateauService>().LifeStyle.Transient);

            container.Register(Component.For<IRoverCommandService>().ImplementedBy<GoForwardCommandService>().LifeStyle.Transient
                .Named("MoveForwardCommandService"));

            container.Register(Component.For<IRoverCommandService>().ImplementedBy<TurnLeftCommandService>().LifeStyle.Transient
                .Named("RotateLeftCommandService"));

            container.Register(Component.For<IRoverCommandService>().ImplementedBy<TurnRightCommandService>().LifeStyle.Transient
                .Named("RotateRightCommandService"));
        }
    }
}
