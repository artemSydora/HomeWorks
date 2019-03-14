using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Calculator
    {
        private static Dictionary<char, Func<Stack<double>, double>> Operations = new Dictionary<char, Func<Stack<double>, double>>
        {
            { '+', stack => stack.Pop() + stack.Pop() },
            { '-', stack => -stack.Pop() + stack.Pop() },
            { '*', stack => stack.Pop() * stack.Pop() },
            { '/', stack => (1 / stack.Pop()) * stack.Pop() },
            { '^', stack => Math.Pow(stack.Pop(), stack.Pop()) }
        };

        public double Calculate(string input)
        {
            var postfixExpression = PostfixNotationExpression.ConvertToPostfixExpression(input);
            var stack = new Stack<double>();
            var result = 0D;
            string number = null;

            for (int i = 0; i < postfixExpression.Length; i++)
            {
                var ch = postfixExpression[i];

                if (char.IsDigit(ch))
                {
                    number += ch;
                    continue;
                }
                else if (number != null)
                {
                    stack.Push(double.Parse(number));
                    number = null;
                }

                if (OperationToken.IsOperationToken(ch))
                {
                    Func<Stack<double>, double> operation = Operations[ch];
                    result = operation(stack);
                    stack.Push(result);
                }
            }

            return result;
        }
    }
}
