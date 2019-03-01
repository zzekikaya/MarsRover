using Castle.Core.Configuration;

namespace MarsRover.CastleIoC
{
    public class ApplicationConfiguration
    {
        private IConfiguration _configuration;
        public ApplicationConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static string inputValue = @"
            5 5
            1 2 N
            LMLMLMLMM
            3 3 E
            MMRMMRMRRM";
        public static string InputValues
        {
            get { return inputValue; }
        }
    }
}
