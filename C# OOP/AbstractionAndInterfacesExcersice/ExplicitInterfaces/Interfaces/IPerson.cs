using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Interfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; }

        void GetName();
    }
}
