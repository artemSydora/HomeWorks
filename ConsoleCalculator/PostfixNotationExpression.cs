using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleCalculator
{
    class PostfixExpression
    {
        private Stack<char> _stack;
        public string postfixExpression, infixExpression, input;
        private char[] _operators = { '(', ')', '+', '-', '*', '/', '^' };

        private byte GetOperatorPriority(char symbol)
        {
            switch (symbol)
            {
                case '(':
                case ')':
                    return 0;
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return 4;
            }
        }

        public bool IsOperator(char symbol)
        {
            foreach (char oper in _operators)
            {
                if (oper == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsDelimeter(char symbol)
        {
            if (" =".IndexOf(symbol) != -1)
                return true;
            return false;
        }

        public string ConvertToPostfixExpression(string input)
        {
                infixExpression = string.Empty;
                postfixExpression = string.Empty;
                _stack = new Stack<char>();
                for (int i = 0; i < input.Length; i++)
                {
                    if (i == 0 && input[0] == '-')
                    {
                        infixExpression += '0';
                    }
                    if ((i < input.Length - 2) && char.IsDigit(input[i + 2]) && IsOperator(input[i]) && IsOperator(input[i + 1]) && input[i + 1] == '-' && input[i] == '(')
                    {
                        infixExpression += '0';
                    }

                    infixExpression += input[i];


                }

                for (int i = 0; i < infixExpression.Length; i++)
                {
                    if (IsDelimeter(infixExpression[i]))
                    {
                        continue;
                    }

                    if (char.IsDigit(infixExpression[i]))
                    {
                        while (!IsDelimeter(infixExpression[i]) && !IsOperator(infixExpression[i]))
                        {
                            postfixExpression += infixExpression[i];
                            i++;
                            if (i == infixExpression.Length)
                                break;
                        }
                        postfixExpression += " ";
                        i--;
                    }

                    if (IsOperator(infixExpression[i]))
                    {
                        if (infixExpression[i] == '(')
                        {
                            _stack.Push(infixExpression[i]);
                        }
                        else
                        if (infixExpression[i] == ')')
                        {
                            char s = (char)_stack.Pop();

                            while (s != '(')
                            {
                                postfixExpression += s.ToString() + ' ';
                                s = (char)_stack.Pop();
                            }

                        }
                        else
                        {
                            if (_stack.Count > 0)
                                if (GetOperatorPriority(infixExpression[i]) <= GetOperatorPriority((char)_stack.Peek()))
                                    postfixExpression += _stack.Pop().ToString() + " ";

                            _stack.Push(char.Parse(infixExpression[i].ToString()));
                        }
                    }
                }
            while (_stack.Count > 0)
            {
                postfixExpression += _stack.Pop() + " ";
            }
            return postfixExpression;
        }


    }
}
