using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Calculator
    {
        // v1 start
        //private static Dictionary<char, Func<Stack<double>, double>> Operations = new Dictionary<char, Func<Stack<double>, double>>
        //{
        //    { '+', stack => stack.Pop() + stack.Pop() },
        //    { '-', stack => -stack.Pop() + stack.Pop() },
        //    { '*', stack => stack.Pop() * stack.Pop() },
        //    { '/', stack => (1 / stack.Pop()) * stack.Pop() },
        //    { '^', stack => Math.Pow(stack.Pop(), stack.Pop()) }
        //};
        // v1 end

        // v2 start
        //private static Dictionary<char, Func<Stack<double>, double>> Operations;
        //static Calculator()
        //{
        //    Operations = new Dictionary<char, Func<Stack<double>, double>>();
        //    Operations.Add('+', MakeAddition);
        //    Operations.Add('-', MakeSubstraction);
        //    Operations.Add('*', MakeMutliplication);
        //    Operations.Add('/', MakeDivision);
        //    Operations.Add('^', MakePower);
        //}

        //private static double MakeAddition(Stack<double> stack)
        //{
        //    return stack.Pop() + stack.Pop();
        //}

        //private static double MakeSubstraction(Stack<double> stack)
        //{
        //    return -stack.Pop() + stack.Pop();
        //}

        //private static double MakeMutliplication(Stack<double> stack)
        //{
        //    return stack.Pop() * stack.Pop();
        //}

        //private static double MakeDivision(Stack<double> stack)
        //{
        //    return (1 / stack.Pop()) * stack.Pop();
        //}

        //private static double MakePower(Stack<double> stack)
        //{
        //    return Math.Pow(stack.Pop(), stack.Pop());
        //}
        // v2 end

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
                    // v1 and v2 uses this
                    //Func<Stack<double>, double> operation = Operations[ch];
                    // result = operation(stack);

                    // v3
                    result = MakeOperation(ch, stack);

                    stack.Push(result);
                }
            }

            return result;
        }

        // v3
        private static double MakeOperation(char operation, Stack<double> stack)
        {
            switch (operation)
            {
                case '+':
                    return stack.Pop() + stack.Pop();

                case '-':
                    return -stack.Pop() + stack.Pop();

                case '*': 
                    return stack.Pop() * stack.Pop();

                case '/': 
                    return (1 / stack.Pop()) * stack.Pop();

                case '^': 
                    return Math.Pow(stack.Pop(), stack.Pop());

                default:
                    throw new InvalidOperationException(string.Format("Unknown operation: '{0}'", operation));
            }
        }
    }
}
