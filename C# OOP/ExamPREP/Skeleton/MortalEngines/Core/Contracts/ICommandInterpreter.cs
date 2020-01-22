using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core.Contracts
{
  public  interface ICommandInterpreter
    {
        string Read(string[] args);
    }
}
