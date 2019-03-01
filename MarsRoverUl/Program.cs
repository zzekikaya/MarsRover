using Business;
using MarsOver.Domain.Entity;
using MarsRover.CastleIoC.DependencyResolver;
using System;

namespace MarsRoverUl
{
    /// <summary>
    /// Bu uygulama .Net Core 2.2.0 kullanılarak yazıldı.
    /// Katmanlı mimari uygunlandı.
    /// inversion of control  patternı kullanıldı.
    /// modeller ve enumlarla çalışıldı.
    /// Castle windsor kullanıldı.
    /// input değeri ApplicationConfiguration okundu.
    /// </summary>
    class Program
    {
        private static IServiceFactory _serviceFactory;
        public static IServiceFactory ServiceFactory
        {
            get
            {
                if (_serviceFactory == null)
                {
                    _serviceFactory = StartupCastle.Resolve<IServiceFactory>();
                }

                return _serviceFactory;
            }
            set
            {
                _serviceFactory = value;
            }
        }

        static void Main(string[] args)
        {
            StartupCastle.Init();

            string inputValues = ServiceFactory.InputProviderService().GetInputValues();

            InputObject inputModel = ServiceFactory.InputModelAssembler().InputModel(inputValues);

            ServiceFactory.PlateauService().IsValidPositionOnThePlateau(inputModel.Plateau.PlateauPosition);

            foreach (var rover in inputModel.RoverList)
            {
                ServiceFactory.RoverService().GoAction(inputModel, rover);

                Console.WriteLine($"{rover.RoverPosition.ToString()}");
            }

            Console.ReadKey();
        }
    }
}

