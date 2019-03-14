using System.Collections.Generic;

namespace Calculator
{
    internal static class PostfixNotationExpression
    {
        public static string ConvertToPostfixExpression(string input)
        {
            var infixExpression = string.Empty;
            var postfixExpression = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0 && input[0] == '-')
                {
                    infixExpression += '0';
                }
                if ((i < input.Length - 2) && char.IsDigit(input[i + 2]) && OperationToken.IsOperationToken(input[i]) && OperationToken.IsOperationToken(input[i + 1]) && input[i + 1] == '-' && input[i] == '(')
                {
                    infixExpression += '0';
                }

                infixExpression += input[i];
            }

            var stack = new Stack<char>();

            for (int i = 0; i < infixExpression.Length; i++)
            {
                char symbol = infixExpression[i];

                if (IsDelimeter(symbol))
                {
                    continue;
                }

                if (char.IsDigit(symbol))
                {
                    while (!IsDelimeter(symbol) && !OperationToken.IsOperationToken(symbol))
                    {
                        postfixExpression += infixExpression[i];
                        i++;

                        if (i == infixExpression.Length)
                        {
                            break;
                        }
                    }

                    postfixExpression += " ";
                    i--;
                }

                if (OperationToken.IsOperationToken(infixExpression[i]))
                {
                    if (infixExpression[i] == '(')
                    {
                        stack.Push(infixExpression[i]);
                    }
                    else if (infixExpression[i] == ')')
                    {
                        char s = stack.Pop();

                        while (s != '(')
                        {
                            postfixExpression += s.ToString() + ' ';
                            s = stack.Pop();
                        }
                    }
                    else
                    {
                        if (stack.Count > 0)
                        {
                            if (OperationToken.GetPriority(infixExpression[i]) <= OperationToken.GetPriority(stack.Peek()))
                            {
                                postfixExpression += stack.Pop().ToString() + " ";
                            }
                        }

                        stack.Push(char.Parse(infixExpression[i].ToString()));
                    }
                }
            }
            while (stack.Count > 0)
            {
                postfixExpression += stack.Pop() + " ";
            }

            return postfixExpression;
        }

        private static bool IsDelimeter(char symbol)
        {
            return symbol == ' ' || symbol == '=';
        }
    }
}
