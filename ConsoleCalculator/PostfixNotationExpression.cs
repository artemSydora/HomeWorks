using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleCalculator
{
    class PostfixNotationExpression
    {
        private Stack<char> _stack;
        public string PostfixExpression { get; set; }
        public string InfixExpression { get; set; }
        public string Input { get; set; }
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

        public string ConvertToPostfixExpression(string Input)
        {
                InfixExpression = string.Empty;
                PostfixExpression = string.Empty;
                _stack = new Stack<char>();
                for (int i = 0; i < Input.Length; i++)
                {
                    if (i == 0 && Input[0] == '-')
                    {
                        InfixExpression += '0';
                    }
                    if ((i < Input.Length - 2) && char.IsDigit(Input[i + 2]) && IsOperator(Input[i]) && IsOperator(Input[i + 1]) && Input[i + 1] == '-' && Input[i] == '(')
                    {
                        InfixExpression += '0';
                    }

                    InfixExpression += Input[i];


                }

                for (int i = 0; i < InfixExpression.Length; i++)
                {
                    char symbol = InfixExpression[i];
                    if (IsDelimeter(symbol))
                        continue;
                    if (char.IsDigit(symbol))
                    {
                        while (!IsDelimeter(symbol) && !IsOperator(symbol))
                        {
                            PostfixExpression += InfixExpression[i];
                            i++;
                            if (i == InfixExpression.Length)
                                break;
                        }
                        PostfixExpression += " ";
                        i--;
                    }
                    if (IsOperator(InfixExpression[i]))
                    {
                        if (InfixExpression[i] == '(')
                        {
                            _stack.Push(InfixExpression[i]);
                        }
                        else
                        if (InfixExpression[i] == ')')
                        {
                            char s = (char)_stack.Pop();

                            while (s != '(')
                            {
                                PostfixExpression += s.ToString() + ' ';
                                s = (char)_stack.Pop();
                            }

                        }
                        else
                        {
                            if (_stack.Count > 0)
                                if (GetOperatorPriority(InfixExpression[i]) <= GetOperatorPriority((char)_stack.Peek()))
                                    PostfixExpression += _stack.Pop().ToString() + " ";

                            _stack.Push(char.Parse(InfixExpression[i].ToString()));
                        }
                    }
                }
            while (_stack.Count > 0)
            {
                PostfixExpression += _stack.Pop() + " ";
            }
            return PostfixExpression;
        }


    }
}
