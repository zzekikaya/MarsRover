using System;
using System.Collections.Generic;
using System.Text;
using MarsOver.Domain.Entity;

namespace Business.Assembler
{
   public interface IInputModelAssembler
    {
        InputObject InputModel(string inputValues);
    }
}
