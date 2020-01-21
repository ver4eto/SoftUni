using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Interfaces
{
  public  interface IResident
    {
        void GetName();
        string Name { get; set; }
        string Country { get; }
    }
}
