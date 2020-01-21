using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Exceptions
{
    public class ExceptionMessages
    {
        public const string InvalidNameMessage = "A name should not be empty.";

        public const string InvalidStatMessage = "{0} should be between {1} and {2}.";

        public const string MissingPlayer = "Player {0} is not in {1} team.";

        public const string MissingTeam = "Team {0} does not exist.";
    }
}
