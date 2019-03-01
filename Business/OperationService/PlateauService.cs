using System;
using System.Collections.Generic;
using System.Text;
using Business.Interface;
using MarsOver.Domain.Entity;

namespace Business.OperationService
{
  public  class PlateauService: IPlateauService
    {
        public void IsValidPositionOnThePlateau(Position position)
        {
            if (position == null || position.X <= 1 || position.Y <= 1)
            {
                throw new CustomException("invalid position value");
            }
        }

        public bool IsNextPositionInBounds(Position position, RoverPosition nextPosition)
        {
            bool result= (nextPosition.X < 0 || nextPosition.Y < 0 || position.X < nextPosition.X || position.Y < nextPosition.Y);
            return result;
        }
    }
}
