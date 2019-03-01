using Business.Interface;
using MarsOver.Domain.Entity;
using MarsOver.Domain.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Business.OperationService
{
    public class RoverService : IRoverService
    {
        private IServiceFactory _serviceFactory { get; set; }
        public RoverService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public void GoAction(InputObject inputModel, Rover currentRover)
        {
            char[] roverCommand = currentRover.CommandParameters.ToCharArray();

            foreach (var command in roverCommand)
            {
                AddRoverPositionHistory(currentRover);

                switch (MapCommandType(command.ToString()))
                {
                    case CommandType.Left:

                        _serviceFactory.RotateLeftCommandService().RunCommand(currentRover.RoverPosition);

                        break;

                    case CommandType.Right:

                        _serviceFactory.RotateRightCommandService().RunCommand(currentRover.RoverPosition);

                        break;

                    case CommandType.MoveForward:

                        _serviceFactory.MoveForwardCommandService().RunCommand(currentRover.RoverPosition);

                        if (_serviceFactory.PlateauService().IsNextPositionInBounds(inputModel.Plateau.PlateauPosition, currentRover.RoverPosition))
                        {
                            currentRover.RoverPosition = currentRover.RoverPositionHistory.Last();
                        }
                        else if (IsThereAnyRoverOnThePosition(inputModel, currentRover))
                        {
                            currentRover.RoverPosition = currentRover.RoverPositionHistory.Last();
                        }

                        break;

                    default:
                        return;

                }
            }
        }

        private CommandType MapCommandType(string command)
        {
            switch (command.ToUpper())
            {
                case "L":
                    return CommandType.Left;
                case "R":
                    return CommandType.Right;
                case "M":
                    return CommandType.MoveForward;
                default:
                    return CommandType.None;
            }
        }

        public bool IsThereAnyRoverOnThePosition(InputObject inputModel, Rover currentRover)
        {
            bool result = inputModel.RoverList.Any(x => x.RoverGuid != currentRover.RoverGuid &&
                                          x.RoverPosition.X == currentRover.RoverPosition.X &&
                                          x.RoverPosition.Y == currentRover.RoverPosition.Y);
            return result;
        }

        public void AddRoverPositionHistory(Rover rover)
        {
            if (rover.RoverPositionHistory == null)
            {
                rover.RoverPositionHistory = new List<RoverPosition>();
            }

            rover.RoverPositionHistory.Add(new RoverPosition
            {
                CurrentDirectionType = rover.RoverPosition.CurrentDirectionType,
                X = rover.RoverPosition.X,
                Y = rover.RoverPosition.Y
            });
        }
    }
}
