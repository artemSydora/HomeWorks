using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    // "Smart enum" pattern
    internal class OperationToken
    {
        private const int DefaultPriority = 4;

        public static readonly OperationToken LeftBracket = new OperationToken('(', 0);
        public static readonly OperationToken RightBracket = new OperationToken(')', 0);
        public static readonly OperationToken Plus = new OperationToken('+', 1);
        public static readonly OperationToken Minus = new OperationToken('-', 1);
        public static readonly OperationToken Multiply = new OperationToken('*', 2);
        public static readonly OperationToken Divide = new OperationToken('/', 2);
        public static readonly OperationToken Power = new OperationToken('^', 3);

        private OperationToken(char value, int priority)
        {
            Value = value;
            Priority = priority;

            TokensHolder.Tokens.Add(this);
        }

        public char Value { get; }

        public int Priority { get; }

        public static bool IsOperationToken(char ch)
        {
            return TokensHolder.Tokens.Any(token => token.Value == ch);
        }

        public static int GetPriority(char tokenValue)
        {
            var foundToken = TokensHolder.Tokens.FirstOrDefault(token => token.Value == tokenValue);

            return foundToken == null ? DefaultPriority : foundToken.Priority;
        }

        // Use this class as it's not possible (for some reason) to use static field in non-static constructor
        private static class TokensHolder
        {
            public static readonly List<OperationToken> Tokens = new List<OperationToken>();
        }
    }
}
