 
 

using MarsOver.Domain.Enum;

namespace MarsOver.Domain.Entity
{
    public class RoverPosition : Position
    {
        public DestinationType CurrentDirectionType { get; set; }

        public override string ToString()
        {
            return $"{X} {Y} {MapCurrentDirectionType(CurrentDirectionType)}";
        }

        private string MapCurrentDirectionType(DestinationType directionType)
        {
            switch (directionType)
            {
                case DestinationType.North:
                    return "N";
                case DestinationType.South:
                    return "S";
                case DestinationType.East:
                    return "E";
                case DestinationType.West:
                    return "W";
                default:
                    return "Destination is not true"; 
                        
            }
        }
    }
}
