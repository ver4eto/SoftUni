using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
   public interface ICommando
    {
        List<IMission> missions { get; }

    }
}
