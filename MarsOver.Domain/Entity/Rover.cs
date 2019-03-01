using System;
using System.Collections.Generic;
using System.Text;

namespace MarsOver.Domain.Entity
{
   public class Rover
    {
        public Guid RoverGuid { get; set; }

        public RoverPosition RoverPosition { get; set; }

        public string CommandParameters { get; set; }

        public List<RoverPosition> RoverPositionHistory { get; set; }
    }
}
