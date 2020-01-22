using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Exceptions
{
   public class ExceptionMessages
    {
        public const string InvalidUsernameException = "Player's username cannot be null or an empty string. ";

        public const string InvalidHealthException = "Player's health bonus cannot be less than zero. ";

        public const string InvalidDamagePoints = "Damage points cannot be less than zero.";

        public const string CardInvalidNameExeption = "Card's name cannot be null or an empty string.";

        public const string CardInvalidDamagePointsExeption = "Card's damage points cannot be less than zero.";

        public const string CardInvalidHealthPointsException = "Card's HP cannot be less than zero.";

        public const string DeadPlayerException = "Player is dead!";

        public const string PlayerIsNullExeption = "Player cannot be null";

        public const string PlayerAlreadyExistException = "Player {0} already exists!";

        public const string CardIsNullExeption = "Card cannot be null!";

        public const string CardAlreadyExistException = "Card {0} already exists!";
    }
}
