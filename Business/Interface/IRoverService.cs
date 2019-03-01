using System;
using System.Collections.Generic;
using System.Text;
using MarsOver.Domain.Entity;

namespace Business.Interface
{
    public interface IRoverService
    {
        void GoAction(InputObject inputModel, Rover currentRover);

        bool IsThereAnyRoverOnThePosition(InputObject inputModel, Rover currentRover);
    }
}
