
using Logger.Enumerations;
using System;

namespace Logger.Contracts
{
   public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
