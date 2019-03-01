using System;
using System.Collections.Generic;
using System.Text;
using MarsOver.Domain.Entity;

namespace Business.Interface
{
    public interface IPlateauService
    {
        void IsValidPositionOnThePlateau(Position position);

        bool IsNextPositionInBounds(Position position, RoverPosition nextPosition);
    }
}
