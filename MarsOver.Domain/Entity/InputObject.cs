using System;
using System.Collections.Generic;
using System.Text; 

namespace MarsOver.Domain.Entity
{
  public  class InputObject
    {
        public Plateau Plateau { get; set; }

        public List<Rover> RoverList { get; set; }
    }
}
