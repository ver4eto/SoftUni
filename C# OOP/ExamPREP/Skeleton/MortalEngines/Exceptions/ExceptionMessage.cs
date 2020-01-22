using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Exceptions
{
  public  class ExceptionMessage
    {
        public const string InvalidMachineNameException = "Machine name cannot be null or empty.";

        public const string PilotIsNullException = "Pilot cannot be null.";

        public const string TargetIsNullException = "Target cannot be null";

        public const string MachineNullException = "Null machine cannot be added to the pilot.";

        public const string PilotInvalidNameException = "Pilot name cannot be null or empty string.";

        public const string TargetNullException =
           "Target cannot be null";

    }
}
