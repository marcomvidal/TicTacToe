using System;
using TicTacToe.Core;

namespace TicTacToe.Verifiers
{
    class Validator
    {
        public void UserEntryIsAnAllowedValue(string chosenPosition)
        {
            bool isNotAnInteger = !int.TryParse(chosenPosition, out int positionAsInteger);
            bool isOutOfRange = !(positionAsInteger > 0 && positionAsInteger < 10);

            RuleEvaluation(
                isNotAnInteger || isOutOfRange,
                "Enter a position between 1 and 9.\n"
            );
        }

        public void PositionChosenIsNotPopulated(Player position)
        {
            bool isAlreadyPopulated = position != null;

            RuleEvaluation(
                isAlreadyPopulated,
                "This position was already taken. Choose another one.\n"
            );
        }

        private void RuleEvaluation(bool rule, string message)
        {
            if (rule) { throw new ApplicationException(message); }
        }
    }
}