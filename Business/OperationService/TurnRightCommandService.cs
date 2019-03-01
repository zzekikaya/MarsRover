using System;
using System.Collections.Generic;
using System.Text;
using Business.Interface;
using MarsOver.Domain.Entity;
using MarsOver.Domain.Enum;

namespace Business.OperationService
{
    public class TurnRightCommandService: IRoverCommandService
    {
        public void RunCommand(RoverPosition roverPosition)
        {
            switch (roverPosition.CurrentDirectionType)
            {
                case DestinationType.North:
                    roverPosition.CurrentDirectionType = DestinationType.East;
                    break;
                case DestinationType.South:
                    roverPosition.CurrentDirectionType = DestinationType.West;
                    break;
                case DestinationType.East:
                    roverPosition.CurrentDirectionType = DestinationType.South;
                    break;
                case DestinationType.West:
                    roverPosition.CurrentDirectionType = DestinationType.North;
                    break;
                default:
                    return;
                    
            }
        }
    }
}
