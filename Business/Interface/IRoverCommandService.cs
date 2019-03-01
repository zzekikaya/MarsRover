using System;
using System.Collections.Generic;
using System.Text; 
using MarsOver.Domain.Entity;

namespace Business.Interface
{
    public interface IRoverCommandService
    {
        void RunCommand(RoverPosition roverPosition);
    }
}
