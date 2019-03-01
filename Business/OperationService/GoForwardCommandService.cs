using Business.Interface;
using MarsOver.Domain.Entity;
using MarsOver.Domain.Enum;

namespace Business.OperationService
{
    public class GoForwardCommandService : IRoverCommandService
    {
        public void RunCommand(RoverPosition roverPosition)
        {
            switch (roverPosition.CurrentDirectionType)
            {
                case DestinationType.North:
                    roverPosition.Y += 1;
                    break;
                case DestinationType.South:
                    roverPosition.Y -= 1;
                    break;
                case DestinationType.East:
                    roverPosition.X += 1;
                    break;
                case DestinationType.West:
                    roverPosition.X -= 1;
                    break;
                default:
                    return;
            }
        }
    }
}
